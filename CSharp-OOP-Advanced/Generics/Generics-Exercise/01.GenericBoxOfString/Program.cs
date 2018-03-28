using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        int lines = int.Parse(Console.ReadLine());

        for (int i = 0; i < lines; i++)
        {
            string input = Console.ReadLine();
            Box<string> box = new Box<string>(input);
            Console.WriteLine(box);
        }
    }
}

