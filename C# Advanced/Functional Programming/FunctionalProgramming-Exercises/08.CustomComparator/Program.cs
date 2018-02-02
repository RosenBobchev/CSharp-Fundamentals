using System;
using System.Linq;

namespace _08.CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var evenNumbers = array.FindAll(x => x % 2 == 0);
            evenNumbers.Sort();
            var oddNumbers = array.FindAll(x => x % 2 != 0);
            oddNumbers.Sort();

            Console.WriteLine(string.Join(" ", evenNumbers.Concat(oddNumbers)));
        }
    }
}
