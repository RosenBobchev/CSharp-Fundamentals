using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01.Regeh
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(\[[^\s[\]]+<(\d+)REGEH(\d+)>[^\s[\]]+])";
            string input = Console.ReadLine();
            List<int> numbers = new List<int>();

            foreach (Match m in Regex.Matches(input, pattern))
            {
                int firstNumber = int.Parse(m.Groups[2].Value);
                int secondNumber = int.Parse(m.Groups[3].ToString());
                numbers.Add(firstNumber);
                numbers.Add(secondNumber);
            }

            for (int i = 1; i < numbers.Count; i++)
            {
                numbers[i] = numbers[i] + numbers[i - 1];
            }
            for (int i = 0; i < numbers.Count; i++)
            {
                int index = numbers[i] % (input.Length - 1);
                string character = input.Substring(index, 1);
                Console.Write(character);
            }
            Console.WriteLine();
        }
    }
}
