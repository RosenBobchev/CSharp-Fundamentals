using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            var dict = new Dictionary<string, Dictionary<string, string>>();

            while ((input = Console.ReadLine()) != "Output")
            {
                string[] splitInput = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                string department = splitInput[0];
                string doctor = $"{splitInput[1]} {splitInput[2]}";
                string patient = splitInput[3];

                if (!dict.ContainsKey(department))
                {
                    dict.Add(department, new Dictionary<string, string>());
                    dict[department].Add(patient, doctor);
                }
                else if (dict[department].Count() < 60)
                {
                    dict[department].Add(patient, doctor);
                }
            }

            string secondInput = "";

            while ((secondInput = Console.ReadLine()) != "End")
            {
                string[] output = secondInput.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                if (output.Length == 1)
                {
                    foreach (var item in dict[output[0]])
                    {
                        Console.WriteLine(item.Key);
                    }
                }
                else if (dict.ContainsKey(output[0]))
                {
                    int index = int.Parse(output[1]);
                    int endIndex = index * 3;
                    int startIndex = endIndex - 3;
                    int count = 0;
                    List<string> list = new List<string>();
                    foreach (var item in dict[output[0]])
                    {

                        if (count >= startIndex && count < endIndex)
                        {
                            list.Add(item.Key);
                        }
                        count++;
                    }

                    foreach (var item in list.OrderBy(x => x))
                    {
                        Console.WriteLine(item);
                    }
                }
                else
                {
                    string doctor = $"{output[0]} {output[1]}";
                    List<string> listofPatients = new List<string>();

                    foreach (var item in dict)
                    {
                        foreach (var s in item.Value)
                        {
                            string doctorValue = s.Value;
                            if (doctorValue == doctor)
                            {
                                listofPatients.Add(s.Key);
                            }
                        }
                    }

                    foreach (var item in listofPatients.OrderBy(x => x))
                    {
                        Console.WriteLine(item);
                    }
                }
            }
        }
    }
}
