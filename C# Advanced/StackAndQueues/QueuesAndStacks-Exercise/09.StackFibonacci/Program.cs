using System;
using System.Collections.Generic;

namespace _09.StackFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var stack = new Stack<long>();

            stack.Push(1);
            stack.Push(1);

            for (int i = 2; i < n; i++)
            {
                var second = stack.Pop();
                var first = stack.Pop();
                var next = first + second;

                stack.Push(first);
                stack.Push(second);
                stack.Push(next);
            }

            Console.WriteLine(stack.Peek());
        }
    }
}
