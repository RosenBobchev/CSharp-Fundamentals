using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        List<int> stones = Console.ReadLine().Split(new string[] { ",", " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

        Lake<int> lake = new Lake<int>(stones);

        Console.WriteLine(string.Join(", ", lake));
    }
}

