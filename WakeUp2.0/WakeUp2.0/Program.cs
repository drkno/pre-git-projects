using System;

namespace WakeUpServer
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var mac = new MacAddress("a1:b2:c3:d4:e5:f6");
            WakeOnLan.WakeUp(mac);
            Console.WriteLine(mac);
            Console.ReadKey();
        }
    }
}
