using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace BinomialDistribution
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int n = 100;
            double p = 0.01;
            double[] rngArray = SetupRng(n, p);
            double total = 0.0;
            for (int i = 0; i < n+1; i++)
            {
                total += rngArray[i];
            }
            Console.WriteLine(total);
            Console.ReadKey();
        }

        private static double[] SetupRng(int n, double p)
        {
            var probabilityArray = new double[n + 1];

            for (var i = 0; i <= n; i++)
            {
                probabilityArray[i] = BinomialProbability(n, i, p);
            }

            return probabilityArray;
        }

        static double BinomialProbability(int n, int k, double p)
        {
            var a = Math.Pow(p, k);
            var b = Math.Pow((1 - p), (n - k));
            return (double)BinomialCoefficient(n, k) * a * b;
        }

        static decimal BinomialCoefficient(decimal n, decimal k)
        {
            if (k > n - k) k = n - k;
            decimal result = 1;
            for (decimal i = 1; i <= k; ++i)
            {
                result *= n - k + i;
                result /= i;
            }
            return result;
        }

    }
}
