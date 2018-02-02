using System;
using System.Linq;

namespace _03.CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> min = FindMinNumber;
            int[] arrayOfNumbers = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            Console.WriteLine(min(arrayOfNumbers));
        }

        private static int FindMinNumber(int[] array)
        {
            int minNumber = int.MaxValue;
            foreach (var number in array)
            {
                if (number < minNumber)
                {
                    minNumber = number;
                }
            }

            return minNumber;
        }
    }
}
