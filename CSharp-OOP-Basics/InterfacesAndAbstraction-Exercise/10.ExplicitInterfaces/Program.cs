using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        string command = string.Empty;

        while ((command = Console.ReadLine()) != "End")
        {
            var tokens = command.Split();
            string name = tokens[0];
            string country = tokens[1];
            int age = int.Parse(tokens[2]);

            Citizen citizen = new Citizen(name, country, age);

            IPerson person = (IPerson)citizen;
            IResident resident = (IResident)citizen;

            Console.WriteLine(person.GetName());
            Console.WriteLine(resident.GetName());
        }
    }
}

