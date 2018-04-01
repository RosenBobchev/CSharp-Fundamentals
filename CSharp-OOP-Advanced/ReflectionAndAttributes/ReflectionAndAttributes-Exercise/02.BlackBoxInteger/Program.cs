using System;
using System.Reflection;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        Type type =  typeof(BlackBoxInteger);

        FieldInfo innerValue = type.GetField("innerValue", BindingFlags.Instance | BindingFlags.NonPublic);
        MethodInfo[] classMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        object instance = Activator.CreateInstance(type, true);
        
        string input = string.Empty;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] tokens = input.Split('_');
            string command = tokens[0];
            int number = int.Parse(tokens[1]);

            MethodInfo method = classMethods.First(m => m.Name == command);

            method.Invoke(instance, new object[] { number });
            Console.WriteLine(innerValue.GetValue(instance));
        }
    }
}

