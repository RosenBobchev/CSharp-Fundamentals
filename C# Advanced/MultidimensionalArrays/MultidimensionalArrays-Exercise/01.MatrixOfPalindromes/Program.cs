using System;
using System.Linq;

namespace _01.MatrixOfPalindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[,] matrix = new int[input[0], input[1]];
            char a = 'a';
            char b = 'a';

            for (int rows = 0; rows < input[0]; rows++)
            {

                for (int columns = 0; columns < input[1]; columns++)
                {
                    Console.Write(a);
                    Console.Write(b);
                    Console.Write(a);
                    Console.Write(" ");
                    b++;
                }

                Console.WriteLine();
                a++;
                b = a;
            }
        }
    }
}
