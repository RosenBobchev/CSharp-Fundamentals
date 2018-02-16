using System;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        Family family = new Family();
        string name = string.Empty;
        int age = 0;

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            name = input[0];
            age = int.Parse(input[1]);

            Person person = new Person();
            person.Name= name;
            person.Age = age;
            family.family.Add(person);
            
        }

        var oldestPerson = family.GetOldestMember();

        Console.WriteLine(oldestPerson.Name + " " + oldestPerson.Age);
    }
}

