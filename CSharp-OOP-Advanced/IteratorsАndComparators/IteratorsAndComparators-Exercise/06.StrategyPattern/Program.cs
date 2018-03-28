using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        SortedSet<Person> sortedNames = new SortedSet<Person>(new NameComparer());
        SortedSet<Person> sortedAges = new SortedSet<Person>(new AgeComparer());
        int numberOfPeople = int.Parse(Console.ReadLine());

        while (--numberOfPeople >= 0)
        {
            string[] tokens = Console.ReadLine().Split();
            string name = tokens[0];
            int age = int.Parse(tokens[1]);

            Person person = new Person(name, age);

            sortedAges.Add(person);
            sortedNames.Add(person);
        }

        Console.WriteLine(string.Join(Environment.NewLine, sortedNames));
        Console.WriteLine(string.Join(Environment.NewLine, sortedAges));
    }
}

