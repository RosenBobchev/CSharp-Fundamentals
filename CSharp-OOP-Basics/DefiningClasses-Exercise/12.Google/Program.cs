using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        var people = new List<Person>();

        string input = string.Empty;
        while ((input = Console.ReadLine()) != "End")
        {
            var tokens = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string personName = tokens[0];

            if (!people.Any(p => p.Name == personName))
            {
                people.Add(new Person(personName));
            }

            var currentPerson = people.FirstOrDefault(p => p.Name == personName);

            if (tokens[1].Equals("company"))
            {
                currentPerson.Company.CompanyName = tokens[2];
                currentPerson.Company.Department = tokens[3];
                currentPerson.Company.Salary = decimal.Parse(tokens[4]);
            }

            if (tokens[1].Equals("pokemon"))
            {
                var pokemon = new Pokemon(tokens[2], tokens[3]);
                currentPerson.Pokemons.Add(pokemon);
            }

            if (tokens[1].Equals("parents"))
            {
                var parent = new Parents(tokens[2], tokens[3]);
                currentPerson.Parents.Add(parent);
            }

            if (tokens[1].Equals("children"))
            {
                var child = new Children(tokens[2], tokens[3]);
                currentPerson.Children.Add(child);
            }

            if (tokens[1].Equals("car"))
            {
                currentPerson.Car.Model = tokens[2];
                currentPerson.Car.Speed = int.Parse(tokens[3]);
            }
        }

        string name = Console.ReadLine();
        var person = people.FirstOrDefault(p => p.Name.Equals(name));

        Console.WriteLine(person);
    }
}

