using System;
using System.Linq;

namespace _05.AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            while (TakeCommand(out string command))
            {
                switch (command)
                {
                    case "add":
                        numbers = numbers.Select(n => n + 1).ToArray();
                        break;
                    case "multiply":
                        numbers = numbers.Select(n => n * 2).ToArray();
                        break;
                    case "subtract":
                        numbers = numbers.Select(n => n - 1).ToArray();
                        break;
                    case "print":
                        Console.WriteLine(string.Join(" ", numbers));
                        break;
                }
            }
        }

        private static bool TakeCommand(out string command)
        {
            command = Console.ReadLine();
            if (command == "end")
            {
                return false;
            }

            return true;
        }
    }
}
