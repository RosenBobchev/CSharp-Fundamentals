using System;
using System.Linq;

[Info("Pesho", 3, "Used for C# OOP Advanced Course - Enumerations and Attributes.", "Pesho", "Svetlio")]
public class StartUp
{
    static void Main(string[] args)
    {
        var attribute = (InfoAttribute)typeof(StartUp).GetCustomAttributes(false).First();

        string command = string.Empty;
        while ((command = Console.ReadLine()) != "END")
        {
            switch (command)
            {
                case "Author":
                    Console.WriteLine($"Author: {attribute.Author}");
                    break;
                case "Revision":
                    Console.WriteLine($"Revision: {attribute.Revision}");
                    break;
                case "Description":
                    Console.WriteLine($"Class description: {attribute.Description}");
                    break;
                case "Reviewers":
                    Console.WriteLine($"Reviewers: {string.Join(", ", attribute.Reviewers)}");
                    break;
            }
        }
    }
}
