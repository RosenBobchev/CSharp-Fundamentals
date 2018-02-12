using System;
using System.Collections.Generic;
using System.Linq;

namespace FourthTask
{
    class Program
    {
        static void Main(string[] args)
        {
            int targetIndex = int.Parse(Console.ReadLine());
            var nameAndInfo = new Dictionary<string, Dictionary<string, string>>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end transmissions")
            {
                var tokens = input.Split(new string[] { "=", ";" }, StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];

                for (int i = 1; i < tokens.Length; i++)
                {
                    if (!nameAndInfo.ContainsKey(name))
                    {
                        nameAndInfo[name] = new Dictionary<string, string>();
                    }
                    var keyAndValue = tokens[i].Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    string key = keyAndValue[0];
                    string value = keyAndValue[1];
                    if (!nameAndInfo[name].ContainsKey(key))
                    {
                        nameAndInfo[name].Add(key, value);
                    }
                    else
                    {
                        nameAndInfo[name][key] = value;
                    }
                }
            }
            string[] killPerson = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string killName = killPerson[1];

            int totalSum = 0;
            Console.WriteLine($"Info on {killName}:");
            foreach (var item in nameAndInfo[killName].OrderBy(x => x.Key))
            {
                Console.WriteLine($"---{item.Key}: {item.Value}");
                int sumKeyLength = item.Key.Length;
                int sumValueLength = item.Value.Length;
                totalSum += sumKeyLength + sumValueLength;
            }

            Console.WriteLine($"Info index: {totalSum}");
            int diff = targetIndex - totalSum;
            if (diff <= 0)
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                Console.WriteLine($"Need {Math.Abs(diff)} more info.");
            }
        }
    }
}
