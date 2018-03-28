using System;

public class Program
{
    static void Main(string[] args)
    {
        var myData = new Box<string>();
        var counter = int.Parse(Console.ReadLine());
        for (int i = 0; i < counter; i++)
        {
            myData.Add(Console.ReadLine());
        }

        string stringToCompare = Console.ReadLine();

        Console.WriteLine(myData.Compare(myData.Data, stringToCompare));
    }
}

