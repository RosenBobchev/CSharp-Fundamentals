using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        Smartphone smartphone = new Smartphone();

        List<string> phones = Console.ReadLine().Split().ToList();
        smartphone.Call(phones);

        List<string> websites = Console.ReadLine().Split().ToList();
        smartphone.Browse(websites);

    }
}

