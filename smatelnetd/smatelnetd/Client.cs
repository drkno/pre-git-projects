using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace smatelnetd
{
    public sealed class Client
    {
        public Socket ClientSocket { get; }
        public IPEndPoint RemoteEndPoint => (IPEndPoint)ClientSocket.RemoteEndPoint;
        private CmdProcess ClientProcess { get; }
        private Thread BackgroundThread { get; }
        private bool BackgroundThreadContinue { get; set; } = true;
        public event Action<Client> Exited;
        private string lastCommand = "";
        private int ignoreCount = 0;
        public Client(Socket socket)
        {
            ClientSocket = socket;
            Send("--- SMA TelnetD ---\r\n");

            var info = new ProcessStartInfo("cmd")
            {
                UseShellExecute = false,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };

            ClientProcess = new CmdProcess
                            {
                                EnableRaisingEvents = true,
                                StartInfo = info
                            };
            ClientProcess.Start();
            ClientProcess.Exited += ClientProcessExited;
            ClientProcess.OutputDataReceived += ProcessOutputDataReceived;
            ClientProcess.ErrorDataReceived += ProcessOutputDataReceived;
            ClientProcess.BeginOutputReadLine();
            ClientProcess.BeginErrorReadLine();

            BackgroundThread = new Thread(ReceiveDataThread);
            BackgroundThread.Start();
        }

        private void ClientProcessExited(object sender, EventArgs e)
        {
            Close();
        }

        private void ReceiveDataThread()
        {
            string command = "";
            while (BackgroundThreadContinue)
            {
                var buffer = new byte[1024];
                var len = ClientSocket.Receive(buffer, SocketFlags.None);
                if (len == 0)
                {
                    continue;
                }
                var data = Encoding.ASCII.GetString(buffer, 0, len);
                command += data;
                if (!data.Contains("\n")) continue;
                var spl = command.Split(new [] {"\r\n","\n"}, StringSplitOptions.None);
                command = "";
                foreach (var s in spl)
                {
                    if (!string.IsNullOrWhiteSpace(s))
                    {
                        lastCommand = s;
                    }
                    ClientProcess.StandardInput.WriteLine(s);
                }
            }
        }

        public void Close()
        {
            BackgroundThreadContinue = false;
            BackgroundThread.Interrupt();
            BackgroundThread.Abort();
            BackgroundThread.Join();
            Send("Have a nice day!");
            ClientSocket.Close();
            ClientProcess.Close();
            OnExited(this);
        }

        private void Send(string data)
        {
            if (data == null) return;
            if (data.Contains("\n"))
            {
                var spl = data.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
                data = string.Join("\r\n", spl);
            }
            ClientSocket.Send(Encoding.Default.GetBytes(data), SocketFlags.None);
        }

        private void ProcessOutputDataReceived(object sender, dynamic e)
        {
            if (e.Data == null) return;
            if (e.Data.Trim() == lastCommand)
            {
                lastCommand = null;
                ignoreCount = 2;
            }

            if (ignoreCount > 0)
            {
                ignoreCount--;
                return;
            }
            Send(e.Data);
        }

        private void OnExited(Client obj)
        {
            Exited?.Invoke(obj);
        }
    }
}
