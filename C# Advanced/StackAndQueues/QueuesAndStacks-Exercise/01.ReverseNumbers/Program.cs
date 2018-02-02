using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ReverseNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] nums = Console.ReadLine().Split(' ');
            var stack = new Stack<string>();

            foreach (var number in nums)
            {
                stack.Push(number);
            }

            while (stack.Count != 0)
            {
                Console.Write(stack.Pop() + " ");
            }
            Console.WriteLine();
        }
    }
}
