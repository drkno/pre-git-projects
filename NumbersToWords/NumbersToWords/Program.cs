using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;

namespace NumbersToWords
{
    internal static class Program
    {
        internal enum Number
        {
            Ignore = 0,
            One = 1,
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9
        }

        internal enum Teens
        {
            Ten = 0,
            Eleven = 1,
            Twelve = 2,
            Thirteen = 3,
            Fourteen = 4,
            Fifteen = 5,
            Sixteen = 6,
            Seventeen = 7,
            Eighteen = 8,
            Nineteen = 9
        }

        internal enum Tens
        {
            Ignore,
            Teen,
            Twenty,
            Thirty,
            Fourty,
            Fifty,
            Sixty,
            Seventy,
            Eighty,
            Ninty
        }

        internal enum Scale
        {
            Start = -1,
            Ignore = 0,
            Thousand = 1,
            Million = 2,
            Billion = 3,
            Trillion = 4,
            Quadrillion = 5,
            Quintillion = 6,
            Sextillion = 7,
            Septillion = 8
        }

        private static IEnumerable<Number> Tokenise(IEnumerable<char> input)
        {
            var num = Number.Ignore;
            return input.TakeWhile(c => Enum.TryParse(c.ToString(), out num)).Select(c => num);
        }

        private static string ToNumberString(string input)
        {
            var stack = new Stack<string>();
            var last = default(Number);
            var j = 0;
            var scale = Scale.Start;
            bool and = false, scaled = false;
            foreach (var token in Tokenise(input.Reverse()))
            {
                if (j == 0)
                {
                    scale++;
                    scaled = false;
                }
                if (token != Number.Ignore)
                {
                    switch (j)
                    {
                        case 0:
                            stack.Push(token.ToString());
                            and = true;
                            break;
                        case 1:
                            var tens = (Tens) (int) token;
                            if (tens == Tens.Teen)
                            {
                                var top = stack.Count > 0 ? stack.Pop() : "";
                                top = top.Contains("-") ? top.Substring(top.IndexOf('-')) : "";
                                stack.Push((Teens) (int) last + top);
                            }
                            else if (last != Number.Ignore)
                            {
                                var top = stack.Pop();
                                stack.Push((Tens) (int) token + "-" + top);
                            }
                            else
                            {
                                stack.Push(((Tens) (int) token).ToString());
                            }
                            and = true;
                            break;
                        case 2:
                            stack.Push(token + "-Hundred" + (and ? " and" : ""));
                            and = false;
                            break;
                    }
                    if (!scaled && scale != Scale.Ignore)
                    {
                        scaled = true;
                        stack.Push(stack.Pop() + "-" + scale + (stack.Count > 0 ? "," : ""));
                    }
                }
                j = (j + 1) % 3;
                last = token;
            }
            return string.Join(" ", stack);
        }

        
        private static readonly OrderedDictionary scale = new OrderedDictionary
        {
            {"Trillion", 1000000000000L},
            {"Billion",  1000000000L},
            {"Million",  1000000L},
            {"Thousand", 1000L},
            {"Hundered", 100L}
        };

        private static string ToNum(long num)
        {
            var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

            if (num < 20)
            {
                return unitsMap[num];
            }
            return tensMap[num / 10] + (num % 10 > 0 ? "-" + unitsMap[num % 10] : "");
        }

        private static string ToNumberString2(long num)
        {
            if (num == 0)
            {
                return "Zero";
            }

            if (num < 0)
            {
                return "Minus " + ToNum(Math.Abs(num));
            }

            var words = "";
            foreach (string key in scale.Keys)
            {
                var val = (long) scale[key];
                if (num / val > 0)
                {
                    words += ToNumberString2(num / val) + $" {key} ";
                    num %= val;
                }
            }

            if (num > 0)
            {
                if (!string.IsNullOrWhiteSpace(words))
                {
                    words += " and ";
                }
                words += ToNum(num);
            }

            return words;
        }

        internal static string ToNumberString(this int number)
        {
            return ToNumberString2(number);
        }

        private static void Main()
        {
            Console.WriteLine(1234.ToNumberString());
            Console.WriteLine(12345.ToNumberString());
            Console.WriteLine(123456.ToNumberString());

            string input;
            while (!string.IsNullOrWhiteSpace(input = Console.ReadLine()))
            {
                Console.WriteLine(ToNumberString2(int.Parse(input)));
            }
        }
    }
}
