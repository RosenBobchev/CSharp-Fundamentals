using System;
using System.Linq;

namespace _02.DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];

            for (int rows = 0; rows < size; rows++)
            {
                var values = Console.ReadLine().Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int column = 0; column < size; column++)
                {
                    matrix[rows, column] = values[column];
                }
            }

            int firstDiagonal = 0;
            int secondDiagonal = 0;

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    if (cols == rows)
                    {
                        firstDiagonal += matrix[rows, cols];
                    }

                    if (cols == matrix.GetLength(1) - 1 - rows)
                    {
                        secondDiagonal += matrix[rows, cols];
                    }
                }
            }

            int diff = Math.Abs(firstDiagonal - secondDiagonal);
            Console.WriteLine(diff);
        }
    }
}
