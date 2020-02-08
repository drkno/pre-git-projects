using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace smatelnetd
{
    public static class Program
    {
        private static Socket _serverSocket;
        private static readonly Dictionary<Socket, Client> ClientList = new Dictionary<Socket, Client>();
        private static Thread _acceptThread;
        private static bool _acceptContinue = true;

        public static void Main()
        {
            Console.WriteLine("SMA TelnetD\n--------------\nServer Started");
            _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            var endPoint = new IPEndPoint(IPAddress.Any, 23);
            _serverSocket.Bind(endPoint);
            _serverSocket.Listen(0);

            _acceptThread = new Thread(AcceptConnection);
            _acceptThread.Start();
            
            Console.WriteLine("Press any key to quit...");
            Console.ReadKey();
            _acceptContinue = false;
            Console.WriteLine("\nKilling Clients.");
            KillClients();
            Console.WriteLine("Killing Wait Process.");
            _acceptThread.Interrupt();
            _acceptThread.Abort();
            _acceptThread.Join();
            _serverSocket.Close();
            Console.WriteLine("Goodbye.");
        }

        private static void AcceptConnection()
        {
            while (_acceptContinue)
            {
                var socket = _serverSocket.Accept();
                if (!_acceptContinue)
                {
                    socket.Close();
                    return;
                }
                var client = new Client(socket);
                ClientList.Add(client.ClientSocket, client);
                Console.WriteLine("Client connected. (From: " + $"{client.RemoteEndPoint.Address}:{client.RemoteEndPoint.Port}" + ")");
                client.Exited += ClientExited;
            }
        }

        private static void ClientExited(Client client)
        {
            ClientList.Remove(client.ClientSocket);
            Console.WriteLine("A client disconnected.");
        }

        private static void KillClients()
        {
            foreach (var client in ClientList)
            {
                client.Value.Close();
            }
        }
    }
}