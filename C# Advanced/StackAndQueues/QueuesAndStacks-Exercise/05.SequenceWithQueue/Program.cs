using System;
using System.Collections.Generic;

namespace _05.SequenceWithQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            long number = long.Parse(Console.ReadLine());
            var queue = new Queue<long>();
            var list = new List<long>();
            list.Add(number);
            queue.Enqueue(number);

            while(list.Count < 50)
            {
                long currentNumber = queue.Dequeue();
                long firstNumber = currentNumber + 1;
                long secondNumber = (currentNumber * 2) + 1;
                long thirdNumber = currentNumber + 2;

                queue.Enqueue(firstNumber);
                queue.Enqueue(secondNumber);
                queue.Enqueue(thirdNumber);
                list.Add(firstNumber);
                list.Add(secondNumber);
                list.Add(thirdNumber);

            }
            for (int i = 0; i < 50; i++)
            {
                Console.Write(list[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
