using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.GroupNumbersList
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            List<int> remainderOne = new List<int>();
            List<int> remainderTwo = new List<int>();
            List<int> remainderZero = new List<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
               int remainder = numbers[i] % 3;
                if (remainder == 1 || remainder == -1)
                {
                    remainderOne.Add(numbers[i]);
                }
                if (remainder == 2 || remainder == -2)
                {
                    remainderTwo.Add(numbers[i]);
                }
                if (remainder == 0)
                {
                    remainderZero.Add(numbers[i]);
                }
            }

            Console.WriteLine(string.Join(" ", remainderZero));
            Console.WriteLine(string.Join(" ", remainderOne));
            Console.WriteLine(string.Join(" ", remainderTwo));
        }
    }
}
