using System;

public class Program
{
    static void Main(string[] args)
    {
        string[] foods = Console.ReadLine().Split();

        Gandalf gandalf = new Gandalf();

        foreach (var food in foods)
        {
            gandalf.EatFood(food);
        }

        Console.WriteLine(gandalf);
    }
}

