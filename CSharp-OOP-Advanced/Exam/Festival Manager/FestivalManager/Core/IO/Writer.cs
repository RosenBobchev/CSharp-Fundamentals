using System;

public class Writer : IWriter
{
    public void Write(string contents)
    {
        Console.Write(contents);
    }

    public void WriteLine(string contents)
    {
        Console.WriteLine(contents);
    }
}