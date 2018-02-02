using System;
using System.Linq;

namespace _03.GroupNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.None)
                  .Select(int.Parse).ToArray();
            var sizes = new int[3];
            foreach (var number in numbers)
            {
                int remainder = Math.Abs(number % 3);
                sizes[remainder]++;
            }

            int[][] array =
            {
                new int[sizes[0]],
                new int[sizes[1]],
                new int[sizes[2]]
            };

            int[] offsets = new int[3];
            foreach (var number in numbers)
            {
                int remainder = Math.Abs(number % 3);
                int index = offsets[remainder];
                array[remainder][index] = number;
                offsets[remainder]++;
            }

            for (int rows = 0; rows < array.Length; rows++)
            {
                for (int columns = 0; columns < array[rows].Length; columns++)
                {
                    Console.Write(array[rows][columns] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
