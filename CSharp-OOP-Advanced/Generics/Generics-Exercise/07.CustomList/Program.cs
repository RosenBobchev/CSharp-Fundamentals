﻿using System;

public class Program
{
    static void Main(string[] args)
    {
        CustomList<string> list = new CustomList<string>();

        string input = string.Empty;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] commandArgs = input.Split();
            string command = commandArgs[0];
            switch (command)
            {
                case "Add":
                    list.Add(commandArgs[1]);
                    break;
                case "Remove":
                    int index = int.Parse(commandArgs[1]);
                    list.Remove(index);
                    break;
                case "Contains":
                    bool result = list.Contains(commandArgs[1]);
                    Console.WriteLine(result);
                    break;
                case "Swap":
                    int firstIndex = int.Parse(commandArgs[1]);
                    int secondIndex = int.Parse(commandArgs[2]);
                    list.Swap(firstIndex, secondIndex);
                    break;
                case "Greater":
                    int count = list.CountGreaterThan(commandArgs[1]);
                    Console.WriteLine(count);
                    break;
                case "Min":
                    string minElement = list.Min();
                    Console.WriteLine(minElement);
                    break;
                case "Max":
                    string maxElement = list.Max();
                    Console.WriteLine(maxElement);
                    break;
                case "Print":
                    for (int i = 0; i < list.Count; i++)
                    {
                        Console.WriteLine(list[i]);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}

