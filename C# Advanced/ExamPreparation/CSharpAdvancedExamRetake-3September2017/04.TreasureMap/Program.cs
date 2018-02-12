using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04.TreasureMap
{
    class Program
    {

        static void Main(string[] args)
        {
            string pattern = @"((?<hash>#)|!)[^#!]*?(?<![a-zA-Z0-9])(?<streetName>[a-zA-Z]{4})(?![a-zA-Z0-9])[^#!]*(?<!\d)(?<streetNumber>\d{3})-(?<password>\d{4}|\d{6})(?!\d)[^#!]*?(?(hash)!|#)";

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();

                MatchCollection matches = Regex.Matches(input, pattern);

                var correctMatch = matches[matches.Count / 2];

                string streetName = correctMatch.Groups["streetName"].Value;
                string streetNumber = correctMatch.Groups["streetNumber"].Value;
                string password = correctMatch.Groups["password"].Value;

                Console.WriteLine($"Go to str. {streetName} {streetNumber}. Secret pass: {password}.");
            }
        }
    }
}
