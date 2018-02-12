using System;
using System.Text;
using System.Text.RegularExpressions;

namespace ThirdTask
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            string pattern = @"((?<hash>{)|\[)[^{[}\]]*?(?<numbersThree>[0-9]{3,})[^{[}\]]*?(?(hash)}|])";
            var text = new StringBuilder();
            string inputLine = string.Empty;

            for (int i = 0; i < input; i++)
            {
                inputLine = Console.ReadLine();
                text.Append(inputLine);
            }

            var textResult = new StringBuilder();
            MatchCollection matches = Regex.Matches(text.ToString(), pattern);

            foreach (Match item in matches)
            {
                string numbers = item.Groups["numbersThree"].ToString();
                int fullMatch = item.Groups[0].Length;

                if (numbers.Length % 3 == 0)
                {
                    int start = 0;
                    for (int i = 0; i < numbers.Length / 3; i++)
                    {
                        string threeNumbers = "";
                        string currentNumber = "";
                        for (int k = 0; k < 3; k++)
                        {
                            currentNumber = numbers[k + start].ToString();
                            threeNumbers += currentNumber;
                        }
                        start += 3;

                        int numbersResult = int.Parse(threeNumbers);
                        char numbersLenght = (char)(numbersResult - fullMatch);
                        string result = numbersLenght.ToString();
                        textResult.Append(result);
                    }
                }
            }

            Console.WriteLine(textResult);
        }
    }
}
