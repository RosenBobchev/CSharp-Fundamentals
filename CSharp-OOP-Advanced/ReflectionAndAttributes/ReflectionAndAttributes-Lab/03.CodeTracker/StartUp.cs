using System;

[SoftUni("class")]
public class StartUp
{
    [SoftUni("main")]
    public static void Main(string[] args)
    {
        var tracker = new Tracker();
        tracker.PrintMethodsByAuthor();
    }
}

