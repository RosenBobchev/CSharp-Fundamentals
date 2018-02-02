using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MaximumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();
            var maxStack = new Stack<int>();
            maxStack.Push(int.MinValue);

            for (int i = 0; i < n; i++)
            {
                int[] number = Console.ReadLine().Split().Select(int.Parse).ToArray();

                int commandNumber = number[0];

                if (commandNumber == 1)
                {
                    int numberToPush = number[1];
                    stack.Push(numberToPush);
                    if (numberToPush >= maxStack.Peek())
                    {
                        maxStack.Push(numberToPush);
                    }
                }
                else if (commandNumber == 2)
                {
                    
                    var elementToDelete = stack.Pop();
                    if (maxStack.Peek() == elementToDelete)
                    {
                        maxStack.Pop();
                    }
                }
                else if (commandNumber == 3)
                {
                    int maxElement = maxStack.Peek();
                    Console.WriteLine(maxElement);
                }
            }
        }
    }
}
