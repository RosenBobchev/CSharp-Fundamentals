using System;

public class Program
{
    static void Main(string[] args)
    {
        Spy spy = new Spy();
        string firstTask = spy.StealFieldInfo("Hacker", "username", "password");
        string secondTask = spy.AnalyzeAcessModifiers("Hacker");
        string thirdTask = spy.RevealPrivateMethods("Hacker");
        string fourthTask = spy.CollectGettersAndSetters("Hacker");

        Console.WriteLine(fourthTask);
    }
}

