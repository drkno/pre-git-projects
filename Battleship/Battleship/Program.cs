using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Battleship
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-------");
            Console.WriteLine("|.....|");
            Console.WriteLine("|.....|");
            Console.WriteLine("|.....|");
            Console.WriteLine("|.....|");
            Console.WriteLine("|.....|");
            Console.WriteLine("|.....|");
            Console.WriteLine("|.....|");
            Console.WriteLine("-------");

            Console.WriteLine("LED: [.]");

            int x = 0;
            int y = 0;

            while (true)
            {
                SetLed(true);
                SetCursor(x, y, '█');
                Thread.Sleep(500);
                SetLed(false);
                SetCursor(x, y, ' ');
                Thread.Sleep(500);
                if (Console.KeyAvailable)
                {
                    SetCursor(x, y, ' ');
                    var key = Console.ReadKey();
                    if (key.Key == ConsoleKey.LeftArrow)
                    {
                        x = x == 0 ? 0 : x - 1;
                    }
                    else if (key.Key == ConsoleKey.RightArrow)
                    {
                        x = x == 4 ? 4 : x + 1;
                    }
                    else if (key.Key == ConsoleKey.UpArrow)
                    {
                        y = y == 0 ? y : y - 1;
                    }
                    else if (key.Key == ConsoleKey.DownArrow)
                    {
                        y = y == 6 ? 6 : y + 1;
                    }
                }
            }
        }

        private static char cur;
        static void SetCursor(int x, int y, char c)
        {
            Console.SetCursorPosition(x+1, y+1);
            if (char.IsWhiteSpace(c))
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write('.');
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(c);
            }
        }

        static void SetLed(bool on)
        {
            Console.SetCursorPosition(6, 9);
            switch (on)
            {
                case true:
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write('█');
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                }
                case false:
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write('-');
                    break;
                }
            }
        }
    }
}
