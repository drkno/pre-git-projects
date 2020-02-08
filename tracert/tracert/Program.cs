using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace tracert
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.Write("Server = ");
                args = new[] {Console.ReadLine()};
            }
            var hostname = args[0];
            var png = new Ping();
            var ttl = 1;
            var pngOpt = new PingOptions {Ttl = ttl};
            var buffer = Encoding.ASCII.GetBytes("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            var hops = 30;
            if(args.Length == 2)
            {
                int.TryParse(args[1], out hops);
            }

            PingReply pngrep;
            do
            {
                pngrep = png.Send(hostname,500,buffer,pngOpt);
                if (pngrep.Address != null)
                {
                    Console.WriteLine(ttl + ": " + pngrep.Address);
                }
                else
                {
                    Console.WriteLine(ttl + ": Unknown");
                }
                ttl++;
                pngOpt.Ttl = ttl;
            } while (pngrep.Status != IPStatus.Success && ttl != hops+1);
            Console.WriteLine("Done or max hops reached.");
            Console.ReadKey();
        }
    }
}
