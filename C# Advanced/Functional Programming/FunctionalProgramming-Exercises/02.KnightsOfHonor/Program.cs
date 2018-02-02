using System;

namespace _02.KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> action = n => Console.WriteLine($"Sir {n}");

            foreach (var name in Console.ReadLine().Split(new string[] { " " },StringSplitOptions.RemoveEmptyEntries))
            {
                action(name);
            }
        }
    }
}
