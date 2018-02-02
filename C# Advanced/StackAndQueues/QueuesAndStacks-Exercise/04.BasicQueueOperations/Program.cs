using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] elements = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var queue = new Queue<int>();

            try
            {
                int elementsToPush = elements[0];
                int elementsToPop = elements[1];
                int elementToFind = elements[2];

                for (int i = 0; i < elementsToPush; i++)
                {
                    queue.Enqueue(numbers[i]);
                }
                for (int i = 0; i < elementsToPop; i++)
                {
                    queue.Dequeue();
                }
                if (queue.Contains(elementToFind))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(queue.Min());
                }
            }
            catch (Exception)
            {
                Console.WriteLine(0);
            }
        }
    }
}
