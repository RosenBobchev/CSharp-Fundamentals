using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class Tracker
{
    public void PrintMethodsByAuthor()
    {
        var type = typeof(StartUp);

        foreach (var method in type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static))
        {
            foreach (var attribute in method.GetCustomAttributes<SoftUniAttribute>())
            {
                Console.WriteLine(attribute.Name);
            }
        }
    }
}

