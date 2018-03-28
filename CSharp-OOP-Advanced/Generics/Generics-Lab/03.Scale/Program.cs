using System;

public class Program
{
    static void Main(string[] args)
    {
        Scale<int> scale = new Scale<int>(2, 2);

        Console.WriteLine(scale.GetHeavier());
    }
}

