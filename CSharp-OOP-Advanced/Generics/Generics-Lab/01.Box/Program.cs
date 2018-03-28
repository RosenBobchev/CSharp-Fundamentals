using System;
    
public class Program
{
    static void Main(string[] args)
    {
        Box<int> box = new Box<int>();

        box.Add(1);
        box.Add(10);
        box.Add(25);
        Console.WriteLine(box.Remove());
        box.Add(20);
        Console.WriteLine(box.Count);
    }
}

