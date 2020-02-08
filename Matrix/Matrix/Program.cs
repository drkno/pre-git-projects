using System;

namespace m7tr1x
{
    class Program
    {
        public static int speed = 10;

        static void Main(string[] args)
        {
            Console.Title = "The Matrix";
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WindowHeight = Console.BufferHeight = Console.LargestWindowHeight;
            Console.WindowWidth = Console.BufferWidth = Console.LargestWindowWidth;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Size the window to the size you want it to be.\n\nWhile Using:\nq:           Quit\nUp Arrow:   Increase Speed\nDown Arrow: Decrease Speed\nDefault Speed of Matrix: 90%\n\nPress any key to continue . . .");
            Console.ReadKey();

            System.Threading.Thread thread = new System.Threading.Thread(speedChanger);

            thread.Start();

            Console.CursorVisible = false;
            int width, height;
            int[] y;
            int[] l;
            Initialize(out width, out height, out y, out l);
            int ms;
            while (true)
            {
                DateTime t1 = DateTime.Now;
                MatrixStep(width, height, y, l);
                ms = speed - (int)((TimeSpan)(DateTime.Now - t1)).TotalMilliseconds;
                if (ms > 0)
                {
                    System.Threading.Thread.Sleep(ms);
                }
                if (Console.KeyAvailable)
                {
                    if (Console.ReadKey().Key == ConsoleKey.F5)
                    {
                        Initialize(out width, out height, out y, out l);
                    }
                }
            }
        }

        static bool thistime = false;

        private static void MatrixStep(int width, int height, int[] y, int[] l)
        {
            int x;
            thistime = !thistime;
            for (x = 0; x < width; ++x)
            {
                if (x % 11 == 10)
                {
                    if (!thistime)
                        continue;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.SetCursorPosition(x, inBoxY(y[x] - 2 - (l[x] / 40 * 2), height));
                    Console.Write(R);
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.SetCursorPosition(x, y[x]);
                Console.Write(R);
                y[x] = inBoxY(y[x] + 1, height);
                Console.SetCursorPosition(x, inBoxY(y[x] - l[x], height));
                Console.Write(' ');
            }
        }

        private static void Initialize(out int width, out int height, out int[] y, out int[] l)
        {
            int h1;
            int h2 = (h1 = (height = Console.WindowHeight) / 2) / 2;
            width = Console.WindowWidth - 1;
            y = new int[width];
            l = new int[width];
            int x;
            Console.Clear();
            for (x = 0; x < width; ++x)
            {
                y[x] = r.Next(height);
                l[x] = r.Next(h2 * ((x % 11 != 10) ? 2 : 1), h1 * ((x % 11 != 10) ? 2 : 1));
            }
        }

        static Random r = new Random();
        static char R
        {
            get
            {
                int t = r.Next(10);
                if (t <= 2)
                {
                    return (char)('0' + r.Next(10));
                }
                else if (t <= 4)
                {
                    return (char)('a' + r.Next(27));
                }
                else if (t <= 6)
                {
                    return (char)('A' + r.Next(27));
                }
                else
                {
                    return (char)(r.Next(32, 255));
                }
            }
        }

        public static int inBoxY(int n, int height)
        {
            n = n % height;
            if (n < 0)
            {
                return n + height;
            }
            else
            {
                return n;
            }
        }

        public static void speedChanger()
        {
            while (true)
            {
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.DownArrow && speed < 100)
                {
                    speed += 10;
                }
                else if (key == ConsoleKey.UpArrow && speed > 0)
                {
                    speed -= 10;
                }
                else if (key == ConsoleKey.Q)
                {
                    Console.WriteLine("NO NO NO NO NO NO NO NO NO NO NO \nDO IT YOURSELF                 \n");
                }
                Console.Title = "The Matrix - Speed: " + ((((double)100 - (double)speed) / (double)100) * (double)100).ToString() + "%";
                System.Threading.Thread.Sleep(500);
                Console.Title = "The Matrix";
            }
        }
    }
}
