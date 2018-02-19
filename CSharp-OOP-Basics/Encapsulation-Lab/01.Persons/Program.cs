using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        int peopleCount = int.Parse(Console.ReadLine());
        var people = new List<Person>();

        for (int i = 0; i < peopleCount; i++)
        {
            var tokens = Console.ReadLine().Split();
            string firstName = tokens[0];
            string lastName = tokens[1];
            int age = int.Parse(tokens[2]);
            var person = new Person(firstName, lastName, age);

            people.Add(person);
        }

        people.OrderBy(x => x.FirstName)
            .ThenBy(a => a.Age)
            .ToList()
            .ForEach(p => Console.WriteLine(p.ToString()));
    }
}

