using System;

namespace _01.ActionPrint
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> action = (n) => Console.WriteLine(n);

            foreach (var name in Console.ReadLine().Split(' '))
            {
                action(name);
            }
        }
    }
}
