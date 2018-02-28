using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        var citizensAndPets = new List<IBirthable>();
        string command = string.Empty;

        while ((command = Console.ReadLine()) != "End")
        {
            AddMembers(citizensAndPets, command);
        }

        string birthdateInput = Console.ReadLine();

        foreach (var member in citizensAndPets.Where(m =>m.BirthDate.EndsWith(birthdateInput)))
        {
            Console.WriteLine(member.BirthDate);
        }
    }

    private static void AddMembers(List<IBirthable> citizensAndPets, string command)
    {
        var tokens = command.Split();
        IBirthable currentMember;

        if (tokens.Length == 5)
        {
            string name = tokens[1];
            int age = int.Parse(tokens[2]);
            string id = tokens[3];
            string birthdate = tokens[4];

            currentMember = new Citizen(name, age, id, birthdate);
            citizensAndPets.Add(currentMember);
        }
        else if (tokens[0] == "Pet" && tokens.Length == 3)
        {
            string name = tokens[1];
            string birthdate = tokens[2];

            currentMember = new Pets(name, birthdate);
            citizensAndPets.Add(currentMember);
        }
    }
}

