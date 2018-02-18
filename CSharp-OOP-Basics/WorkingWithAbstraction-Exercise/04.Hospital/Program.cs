using System;
using System.Collections.Generic;
using System.Linq;

public class Program
 {
     static void Main()
     {
         Dictionary<string, List<string>> doctors = new Dictionary<string, List<string>>();
         Dictionary<string, List<List<string>>> departments = new Dictionary<string, List<List<string>>>();


         string command = string.Empty;
         while ((command = Console.ReadLine()) != "Output")
        {
            command = FillDicts(doctors, departments, command);
        }

        command = string.Empty;

         while ((command = Console.ReadLine()) != "End")
        {
            command = PrintResult(doctors, departments, command);
        }
    }

    private static string PrintResult(Dictionary<string, List<string>> doctors, Dictionary<string, List<List<string>>> departments, string command)
    {
        string[] tokens = command.Split();

        if (tokens.Length == 1)
        {
            Console.WriteLine(string.Join("\n", departments[tokens[0]].Where(x => x.Count > 0).SelectMany(x => x)));
        }
        else if (tokens.Length == 2 && int.TryParse(tokens[1], out int room))
        {
            Console.WriteLine(string.Join("\n", departments[tokens[0]][room - 1].OrderBy(x => x)));
        }
        else
        {
            Console.WriteLine(string.Join("\n", doctors[tokens[0] + tokens[1]].OrderBy(x => x)));
        }
        return command;
    }

    private static string FillDicts(Dictionary<string, List<string>> doctors, Dictionary<string, List<List<string>>> departments, string command)
    {
        string[] tokens = command.Split();
        var departament = tokens[0];
        var firstName = tokens[1];
        var secondName = tokens[2];
        var patient = tokens[3];
        var fullName = firstName + secondName;

        if (!doctors.ContainsKey(firstName + secondName))
        {
            doctors[fullName] = new List<string>();
        }
        if (!departments.ContainsKey(departament))
        {
            departments[departament] = new List<List<string>>();
            for (int rooms = 0; rooms < 20; rooms++)
            {
                departments[departament].Add(new List<string>());
            }
        }

        bool hasPlace = departments[departament].SelectMany(x => x).Count() < 60;
        if (hasPlace)
        {
            int room = 0;
            doctors[fullName].Add(patient);
            for (int rooms = 0; rooms < departments[departament].Count; rooms++)
            {
                if (departments[departament][rooms].Count < 3)
                {
                    room = rooms;
                    break;
                }
            }
            departments[departament][room].Add(patient);
        }
        
        return command;
    }
}
  
