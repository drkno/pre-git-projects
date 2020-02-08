using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Dir615EmergencyUpload
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileBytes = File.ReadAllBytes(@"openwrt-ar71xx-generic-dir-615-e4-squashfs-factory.bin");

            HttpWebRequest webRequest = (HttpWebRequest) WebRequest.Create("http://192.168.0.1/cgi/index");
            webRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:45.0) Gecko/20100101 Firefox/45.0";
            webRequest.AllowAutoRedirect = true;
            webRequest.Method = "POST";
            webRequest.ContentType = "multipart/form-data";
            webRequest.GetRequestStream().Write(fileBytes, 0, fileBytes.Length);
            webRequest.GetRequestStream().Close();
            webRequest.ServicePoint.Expect100Continue = false;

            using (var response = (HttpWebResponse) webRequest.GetResponse())
            {
                var readder = new StreamReader(response.GetResponseStream());
                Console.WriteLine(readder.ReadToEnd());
                readder.Close();
            }

           /* var headerBytes = Encoding.UTF8.GetBytes("POST /cgi/index HTTP/1.1\r\nUser-Agent: Testing\r\nHost: 192.168.0.1\r\nContent-Length: " + fileBytes.Length + "\r\n\r\n");
            var finalBytes = Encoding.UTF8.GetBytes("\r\n\r\n");

            var requestBytes = new byte[fileBytes.Length + headerBytes.Length + finalBytes.Length];
            headerBytes.CopyTo(requestBytes, 0);
            fileBytes.CopyTo(requestBytes, headerBytes.Length);
            finalBytes.CopyTo(requestBytes, headerBytes.Length + fileBytes.Length);

            Debug.Assert(headerBytes.Length + fileBytes.Length == requestBytes.Length - finalBytes.Length);
            //Console.WriteLine(Encoding.UTF8.GetString(requestBytes));
            Debug.WriteLine(Encoding.UTF8.GetString(requestBytes));
            Console.WriteLine("----");
            Debug.WriteLine("----");

            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect("192.168.0.1", 80);
            socket.Send(requestBytes);
            var responseBytes = new byte[socket.ReceiveBufferSize];
            socket.Receive(responseBytes);
            var rxd = Encoding.UTF8.GetString(responseBytes);
            Console.Out.Write(rxd);
            Debug.Write(rxd);*/
            Console.ReadKey();
        }
    }
}
