using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        int peopleCount = int.Parse(Console.ReadLine());
        var Team = new Team("my team");

        for (int i = 0; i < peopleCount; i++)
        {
            var tokens = Console.ReadLine().Split();
            try
            {
                string firstName = tokens[0];
                string lastName = tokens[1];
                int age = int.Parse(tokens[2]);
                decimal salary = decimal.Parse(tokens[3]);
                var person = new Person(firstName, lastName, age, salary);
                Team.AddPlayer(person);

            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine(argEx.Message);
            }

        }

        Console.WriteLine($"First team has {Team.FirstTeam.Count} players.");
        Console.WriteLine($"Reserve team has {Team.ReserveTeam.Count} players.");
    }
}

