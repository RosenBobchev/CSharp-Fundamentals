using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] elements = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var stack = new Stack<int>();

            try
            {
                int elementsToPush = elements[0];
                int elementsToPop = elements[1];
                int elementToFind = elements[2];

                for (int i = 0; i < elementsToPush; i++)
                {
                    stack.Push(numbers[i]);
                }
                for (int i = 0; i < elementsToPop; i++)
                {
                    stack.Pop();
                }
                if (stack.Contains(elementToFind))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(stack.Min());
                }
            }
            catch (Exception)
            {
                Console.WriteLine(0);
            }
        }
    }
}
