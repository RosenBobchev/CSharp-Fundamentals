using System;

public class Program
{
    static void Main(string[] args)
    {
        var myData = new Box<double>();
        var counter = int.Parse(Console.ReadLine());
        for (int i = 0; i < counter; i++)
        {
            myData.Add(double.Parse(Console.ReadLine()));
        }

        double numberToCompare = double.Parse(Console.ReadLine());

        Console.WriteLine(myData.Compare(myData.Data, numberToCompare));
    }
}

