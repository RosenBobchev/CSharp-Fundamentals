using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.PredicateParty
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            while (TakeCommand(out string[] command))
            {
                string firstParam = command[0];
                string secondParam = command[1];
                string thirdParam = command[2];

                switch (secondParam)
                {
                    case "StartsWith":
                        ApplyChanges(names, firstParam, n => n.StartsWith(thirdParam));
                        break;
                    case "EndsWith":
                        ApplyChanges(names, firstParam, n => n.EndsWith(thirdParam));
                        break;
                    case "Length":
                        int length = int.Parse(thirdParam);
                        ApplyChanges(names, firstParam, n => n.Length == length);
                        break;
                }
            }

            if (names.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            {
                Console.WriteLine(string.Join(", ", names) + " are going to the party!");
            }
        }

        private static void ApplyChanges(List<string> names, string firstParam, Func<string, bool> func)
        {
            for (int i = names.Count - 1; i >= 0; i--)
            {
                if (func(names[i]))
                {
                    if (firstParam == "Double")
                    {
                        names.Add(names[i]);
                    }
                    else if (firstParam == "Remove")
                    {
                        names.RemoveAt(i);
                    }
                }
            }
        }

        private static bool TakeCommand(out string[] command)
        {
            command = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            if (command[0] == "Party!")
            {
                return false;
            }
            return true;
        }
    }
}
