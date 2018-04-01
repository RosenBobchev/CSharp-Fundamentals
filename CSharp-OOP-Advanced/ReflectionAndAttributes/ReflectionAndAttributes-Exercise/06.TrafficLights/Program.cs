using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split();
        int cycle = int.Parse(Console.ReadLine());

        for (int i = 0; i < cycle; i++)
        {
            ChangeLights(input);
            Console.WriteLine(string.Join(" ", input));
        }
    }

    private static void ChangeLights(string[] input)
    {
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == LightsEnum.Yellow.ToString())
            {
                input[i] = LightsEnum.Red.ToString();
            }
            else if (input[i] == LightsEnum.Red.ToString())
            {
                input[i] = LightsEnum.Green.ToString();
            }
            else if (input[i] == LightsEnum.Green.ToString())
            {
                input[i] = LightsEnum.Yellow.ToString();
            }
        }
    }
}
