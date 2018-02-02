using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.BalancedParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();

            if (input.Length % 2 != 0)
            {
                Console.WriteLine("NO");
                return;
            }

            char[] opening = new [] { '(', '[', '{' };
            char[] closing = new [] { ')', ']', '}' };

            var stack = new Stack<char>();

            foreach (var element in input)
            {
                if (opening.Contains(element))
                {
                    stack.Push(element);
                }
                else if (closing.Contains(element))
                {
                    var lastElement = stack.Pop();
                    int openingIndex = Array.IndexOf(opening, lastElement);
                    int closingIndex = Array.IndexOf(closing, element);

                    if (openingIndex != closingIndex)
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
            }

            if (stack.Any())
            {
                Console.WriteLine("No");
            }
            else
            {
                Console.WriteLine("YES");
            }
        }
    }
}
