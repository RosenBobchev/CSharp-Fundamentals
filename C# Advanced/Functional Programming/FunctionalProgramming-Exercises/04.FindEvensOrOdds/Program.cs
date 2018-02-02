using System;
using System.Linq;

namespace _04.FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int lower = input[0];
            int upper = input[1];

            string command = Console.ReadLine();

            Predicate<int> predicate = EvenOrOdd;

            for (int i = lower; i <= upper; i++)
            {
                if (command == "even" && predicate(i))
                {
                    Console.Write(i + " ");
                }
                else if (command == "odd" && !predicate(i))
                {
                    Console.Write(i + " ");
                }
            }
            Console.WriteLine();
        }

        private static bool EvenOrOdd(int number)
        {
            return number % 2 == 0;
        }
    }
}
