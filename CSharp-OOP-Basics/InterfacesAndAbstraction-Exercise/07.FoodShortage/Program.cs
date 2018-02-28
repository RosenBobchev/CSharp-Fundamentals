using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        int inputCount = int.Parse(Console.ReadLine());
        var people = new List<IBuyer>();

        for (int i = 0; i < inputCount; i++)
        {
            var input = Console.ReadLine().Split();
            AddPeople(people, input);
        }

        string command = string.Empty;
        while ((command = Console.ReadLine()) != "End")
        {
            if (people.Any(x => x.Name == command))
            {
                people.First(x => x.Name == command).BuyFood();
            }
        }

        Console.WriteLine(people.Sum(x => x.Food));
    }

    private static void AddPeople(List<IBuyer> people, string[] input)
    {
        if (input.Length == 4)
        {
            string name = input[0];
            int age = int.Parse(input[1]);
            string id = input[2];
            string birthdate = input[3];

            Citizen citizen = new Citizen(name, age, id, birthdate);
            people.Add(citizen);
        }
        else if (input.Length == 3)
        {
            string name = input[0];
            int age = int.Parse(input[1]);
            string group = input[2];

            Rebel rebel = new Rebel(name, age, group);
            people.Add(rebel);
        }
    }
}

