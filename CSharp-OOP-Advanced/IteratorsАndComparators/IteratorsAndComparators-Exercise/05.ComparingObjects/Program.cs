using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        List<Person> people = new List<Person>();
        string command = string.Empty;

        while ((command = Console.ReadLine()) != "END")
        {
            var tokens = command.Split();

            string name = tokens[0];
            int age = int.Parse(tokens[1]);
            string town = tokens[2];

            Person person = new Person(name, age, town);
            people.Add(person);
        }

        int personToCompare = int.Parse(Console.ReadLine());

        Person personToSearch = people[personToCompare - 1];

        int counter = 0;

        foreach (var person in people)
        {
            if (personToSearch.CompareTo(person) == 0)
            {
                counter++;
            }
        }
        if (counter == 1)
        {
            Console.WriteLine("No matches");
        }
        else
        {
            Console.WriteLine($"{counter} {people.Count - counter} {people.Count}");
        }
    }
}

