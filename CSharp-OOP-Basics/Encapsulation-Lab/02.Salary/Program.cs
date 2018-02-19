using System;
using System.Collections.Generic;

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
            decimal salary = decimal.Parse(tokens[3]);
            var person = new Person(firstName, lastName, age, salary);

            people.Add(person);
        }

        decimal percentage = decimal.Parse(Console.ReadLine());

        people.ForEach(p => p.IncreaseSalary(percentage));
        people.ForEach(p => Console.WriteLine(p.ToString()));
    }
}

