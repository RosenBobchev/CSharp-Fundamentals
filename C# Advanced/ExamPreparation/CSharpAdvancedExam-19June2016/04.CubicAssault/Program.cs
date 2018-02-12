using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.CubicAssault
{
    class Program
    {
        private static Dictionary<string, Dictionary<string, long>> regions = new Dictionary<string, Dictionary<string, long>>();

        static void Main(string[] args)
        {
            while (TakeInput(out string region, out string legion, out long amount))
            {
                if (!regions.ContainsKey(region))
                {
                    regions.Add(region, new Dictionary<string, long>()
                    {
                        {"Green", 0L },
                        {"Red", 0L },
                        {"Black", 0L }
                    });
                }

                regions[region][legion] += amount;

                SetRegions(region);
            }

            Print();
        }

        private static void Print()
        {
            regions = regions.OrderByDescending(r => r.Value["Black"]).ThenBy(r => r.Key.Length).ThenBy(r => r.Key).ToDictionary(x => x.Key, v => v.Value);

            foreach (var region in regions)
            {
                Console.WriteLine(region.Key);
                foreach (var legion in region.Value.OrderByDescending(v => v.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"-> {legion.Key} : {legion.Value}");
                }
            }
        }

        private static void SetRegions(string region)
        {
            if (regions[region]["Green"] >= 1_000_000)
            {
                long greenAmount = regions[region]["Green"];
                long toMove = greenAmount / 1_000_000;
                regions[region]["Green"] = greenAmount % 1_000_000;
                regions[region]["Red"] += toMove;
            }

            if (regions[region]["Red"] >= 1_000_000)
            {
                long redAmount = regions[region]["Red"];
                long toMove = redAmount / 1_000_000;
                regions[region]["Red"] = redAmount % 1_000_000;
                regions[region]["Black"] += toMove;
            }
        }

        private static bool TakeInput(out string region, out string legion, out long amount)
        {
            region = string.Empty;
            legion = string.Empty;
            amount = 0;

            string input = Console.ReadLine();
            if (input == "Count em all")
            {
                return false;
            }
            string[] inputArray = input.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            region = inputArray[0];
            legion = inputArray[1];
            amount = long.Parse(inputArray[2]);

            return true;
        }
    }
}
