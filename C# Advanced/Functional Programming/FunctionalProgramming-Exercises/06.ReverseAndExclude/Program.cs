using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int divisor = int.Parse(Console.ReadLine());

            numbers.Reverse();
            numbers = numbers.Where(n => Filter(n, x => x % divisor != 0)).ToList();

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static bool Filter(int number, Func<int, bool> filter)
        {
            return filter(number);
        }
    }
}
