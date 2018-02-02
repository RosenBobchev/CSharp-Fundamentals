using System;

namespace _08.RecursiveFibonacci
{
    class Program
    {
        private static long[] memorization;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            memorization = new long[n + 1];

            Console.WriteLine(GetFibonacci(n));
        }

        private static long GetFibonacci(int n)
        {
            if (n <= 2)
            {
                return 1;
            }
            if (memorization[n] != 0)
            {
                return memorization[n];
            }

            memorization[n] = GetFibonacci(n - 1) + GetFibonacci(n - 2);

            return memorization[n];
        }
    }
}
