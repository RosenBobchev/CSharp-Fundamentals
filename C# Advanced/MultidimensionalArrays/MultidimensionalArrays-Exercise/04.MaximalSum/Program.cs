using System;
using System.Linq;

namespace _04.MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int[,] matrix = new int[size[0], size[1]];

            for (int rows = 0; rows < size[0]; rows++)
            {
                var values = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                for (int column = 0; column < size[1]; column++)
                {
                    matrix[rows, column] = values[column];
                }
            }

            int currSum = 0;
            int sum = 0;
            int currentRow = 0;
            int currentCol = 0;

            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                        currSum = CalculateSum(ref matrix, row, col);

                    if (currSum > sum)
                    {
                        sum = currSum;
                        currentRow = row;
                        currentCol = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {sum}");

            for (int rows = currentRow; rows < currentRow + 3; rows++)
            {
                for (int cols = currentCol; cols < currentCol + 3; cols++)
                {
                    Console.Write(matrix[rows, cols] + " ");
                }

                Console.WriteLine();
            }
        }

        private static int CalculateSum(ref int[,] matrix, int startRow, int startCol)
        {
            var sum = 0;

            for (var row = startRow; row < startRow + 3; row++)
            {
                for (var col = startCol; col < startCol + 3; col++)
                {
                    sum += matrix[row, col];
                }
            }

            return sum;
        }
    }
}
