using System;
using System.Linq;
using System.Reflection;

public class Program
{
    static void Main(string[] args)
    {
        string command = string.Empty;
        var classType = typeof(HarvestingFields);
        var fields = classType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        
        while ((command = Console.ReadLine()) != "HARVEST")
        {
            switch (command)
            {
                case "private":
                    Print(fields.Where(f => f.IsPrivate).ToArray());
                    break;
                case "protected":
                    Print(fields.Where(f => f.IsFamily).ToArray());
                    break;
                case "public":
                    Print(fields.Where(f => f.IsPublic).ToArray());
                    break;
                case "all":
                    Print(fields);
                    break;
            }
        }
    }

    private static void Print(FieldInfo[] fields)
    {
        foreach (var field in fields)
        {
            string accessModifier = field.IsFamily ? "protected" : field.Attributes.ToString().ToLower();
            Console.WriteLine($"{accessModifier} {field.FieldType.Name} {field.Name}");
        }
    }
}

