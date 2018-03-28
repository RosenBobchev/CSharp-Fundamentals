using System;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        var myList = new Box<string>();

        var count = int.Parse(Console.ReadLine());
        for (int i = 0; i < count; i++)
        {
            var input = Console.ReadLine();
            myList.Add(input);
        }

        var indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
        myList.Swap(indexes[0], indexes[1]);

        Console.WriteLine(myList);
    }
}

