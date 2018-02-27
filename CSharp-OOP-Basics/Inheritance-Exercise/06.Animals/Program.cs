using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        List<Animals> animals = new List<Animals>();
        string command = string.Empty;

        while ((command = Console.ReadLine()) != "Beast!")
        {
            try
            {
                CreateAndAddAnimals(animals, command);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        foreach (var animal in animals)
        {
            Console.WriteLine(animal);
        }
    }

    private static void CreateAndAddAnimals(List<Animals> animals, string command)
    {
        var tokens = Console.ReadLine().Split();
        string name = tokens[0];
        int age = int.Parse(tokens[1]);

        string gender = string.Empty;
        if (tokens.Length == 3)
        {
            gender = tokens[2];
        }

        switch (command)
        {
            case "Cat":
                var cat = new Cat(name, age, gender);
                animals.Add(cat);
                break;
            case "Dog":
                var dog = new Dog(name, age, gender);
                animals.Add(dog);
                break;
            case "Frog":
                var frog = new Frog(name, age, gender);
                animals.Add(frog);
                break;
            case "Kitten":
                var kitten = new Kitten(name, age);
                animals.Add(kitten);
                break;
            case "Tomcat":
                var tomcat = new Tomcat(name, age);
                animals.Add(tomcat);
                break;
            default:
                throw new ArgumentException("Invalid input!");
        }
    }
}

