using System;
using System.Collections.Generic;

namespace _06.TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var queue = new Queue<string>();
            int count = 0;
            string command = Console.ReadLine();

            while (command != "end")
            {
                if (command == "green")
                {
                    var carsThatCanPass = Math.Min(queue.Count, n);
                    for (int i = 0; i < carsThatCanPass; i++)
                    {
                        Console.WriteLine($"{queue.Dequeue()} passed!");
                        count++;
                    }
                }
                else
                {
                    queue.Enqueue(command);
                }
                command = Console.ReadLine();
            }

            Console.WriteLine($"{count} cars passed the crossroads.");
        }
    }
}
