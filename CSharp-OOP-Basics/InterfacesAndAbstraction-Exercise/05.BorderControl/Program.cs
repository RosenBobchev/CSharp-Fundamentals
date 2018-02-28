using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        var contained = new List<IIdentable>();

        string command = string.Empty;
        while ((command = Console.ReadLine()) != "End")
        {
            AddMembers(contained, command);
        }

        string fakeId = Console.ReadLine();
        foreach (var member in contained.Where(m => m.Id.EndsWith(fakeId)))
        {
            Console.WriteLine(member.Id);
        }
    }

    private static void AddMembers(List<IIdentable> contained, string command)
    {
        var tokens = command.Split();
        IIdentable currentMember = null;

        if (tokens.Length == 3)
        {
            currentMember = new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2]);
        }
        else if (tokens.Length == 2)
        {
            currentMember = new Robot(tokens[0], tokens[1]);
        }

        contained.Add(currentMember);
    }
}

