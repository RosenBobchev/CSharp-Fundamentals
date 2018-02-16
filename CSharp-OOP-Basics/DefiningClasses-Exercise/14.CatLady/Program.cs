using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        var cats = new List<Cats>();
        string command = string.Empty;

        while ((command = Console.ReadLine()) != "End")
        {
            var tokens = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string breed = tokens[0];
            string name = tokens[1];
            double property = double.Parse(tokens[2]);

            var cat = new Cats(breed, name);

            if (breed.Equals("StreetExtraordinaire"))
            {
                cat.Decibels = property;
            }
            else if (breed.Equals("Siamese"))
            {
                cat.EarSize = property;
            }
            else if (breed.Equals("Cymric"))
            {
                cat.FurLength = property;
            }

            cats.Add(cat);
        }

        string catName = Console.ReadLine();
        var catResult = cats.FirstOrDefault(c => c.Name.Equals(catName));
        Console.WriteLine(catResult);
    }
}

