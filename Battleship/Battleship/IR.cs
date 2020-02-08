using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class IR
    {
        private static NamedPipeClientStream namedPipeClient;
        private static StreamReader namedPipeReader;
        private static StreamWriter namedPipeWriter;
        public static void init_ir()
        {
            namedPipeClient = new NamedPipeClientStream("Battleship");
            namedPipeClient.Connect();

            namedPipeReader = new StreamReader(namedPipeClient);
            namedPipeWriter = new StreamWriter(namedPipeClient);
        }

        public static char read()
        {
            char input = ' ';
            while (!char.IsWhiteSpace(input))
            {
                input = (char)namedPipeReader.Read();
            }
            return input;
        }

        public static void write(char c)
        {
            namedPipeWriter.Write(c);
        }
    }
}
