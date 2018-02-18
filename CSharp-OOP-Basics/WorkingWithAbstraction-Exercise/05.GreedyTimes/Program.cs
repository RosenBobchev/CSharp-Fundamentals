using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        long bagCapacity = long.Parse(Console.ReadLine());
        string[] info = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        var bag = new Dictionary<string, Dictionary<string, long>>();
        long gold = 0;
        long gems = 0;
        long cash = 0;

        for (int i = 0; i < info.Length; i += 2)
        {
            string name, input;
            long amount = int.Parse(info[i + 1]);
            long total = gold + gems + cash;

            if (bagCapacity < total + amount)
            {
                continue;
            }
            CheckBagName(info, i, out name, out amount, out input);

            switch (input)
            {
                case "Gold":
                    gold += amount;
                    FillBag(bag, ref gold, ref gems, ref cash, name, amount, input);
                    break;
                case "Gem":
                    if (gems + amount <= gold)
                    {
                        gems += amount;
                        FillBag(bag, ref gold, ref gems, ref cash, name, amount, input);
                    }
                    break;
                case "Cash":
                    if (cash + amount <= gems)
                    {
                        cash += amount;
                        FillBag(bag, ref gold, ref gems, ref cash, name, amount, input);
                    }
                    break;
            }
        }

        PrintBag(bag);
    }

    private static void CheckBagName(string[] info, int i, out string name, out long amount, out string input)
    {
        name = info[i];
        amount = long.Parse(info[i + 1]);
        input = string.Empty;
        if (name.Length == 3)
        {
            input = "Cash";
        }
        else if (name.ToLower().EndsWith("gem"))
        {
            input = "Gem";
        }
        else if (name.ToLower() == "gold")
        {
            input = "Gold";
        }
    }

    private static void FillBag(Dictionary<string, Dictionary<string, long>> bag, ref long gold, ref long gems, ref long cash, string name, long amount, string input)
    {
        if (!bag.ContainsKey(input))
        {
            bag[input] = new Dictionary<string, long>();
        }

        if (!bag[input].ContainsKey(name))
        {
            bag[input][name] = 0;
        }

        bag[input][name] += amount;
    }

    private static void PrintBag(Dictionary<string, Dictionary<string, long>> bag)
    {
        foreach (var item in bag)
        {
            Console.WriteLine($"<{item.Key}> ${item.Value.Values.Sum()}");
            foreach (var itemValue in item.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
            {
                Console.WriteLine($"##{itemValue.Key} - {itemValue.Value}");
            }
        }
    }
}

