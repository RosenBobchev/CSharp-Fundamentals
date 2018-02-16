using System;

public class Program
{
    static void Main(string[] args)
    {
        StudentSystem studentSystem = new StudentSystem();
        while (true)
        {
            studentSystem.ParseCommand();
        }
    }
}

