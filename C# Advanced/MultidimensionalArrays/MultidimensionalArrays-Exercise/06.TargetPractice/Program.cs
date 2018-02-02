using System;
using System.Linq;

namespace _06.TargetPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            InitMatrix(out var matrix);

            FillMatrix(ref matrix);

            var shotParameters = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var shotRow = shotParameters[0];
            var shotCol = shotParameters[1];
            var radius = shotParameters[2];

            CleanBlastedArea(ref matrix, shotRow, shotCol, radius);

            FallingDown(ref matrix);

            PrintMatrix(ref matrix);
        }

        private static void FallingDown(ref char[][] matrix)
        {
            var hasChange = true;
            while (hasChange)
            {
                hasChange = false;
                for (int row = 0; row < matrix.Length - 1; row++)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        var currentSymbol = matrix[row][col];

                        if (matrix[row + 1][col] == ' ' && matrix[row][col] != ' ')
                        {
                            hasChange = true;
                            matrix[row + 1][col] = currentSymbol;
                            matrix[row][col] = ' ';
                        }
                    }
                }
            }
        }

        private static void CleanBlastedArea(ref char[][] matrix, int shotRow, int shotCol, int radius)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (IsInsideRadius(row, col, shotRow, shotCol, radius))
                    {
                        matrix[row][col] = ' ';
                    }
                }
            }
        }

        private static bool IsInsideRadius(int row, int col, int shotRow, int shotCol, int radius)
        {
            var deltaRow = row - shotRow;
            var deltaCol = col - shotCol;

            var isInRadius = deltaRow * deltaRow + deltaCol * deltaCol <= radius * radius;

            return isInRadius;
        }

        private static void FillMatrix(ref char[][] matrix)
        {
            var snake = Console.ReadLine().ToCharArray();
            var snakeIndex = 0;
            var toLeft = true;

            for (int row = matrix.Length - 1; row >= 0; row--)
            {
                if (toLeft)
                {
                    for (int col = matrix[row].Length - 1; col >= 0; col--)
                    {
                        if (snakeIndex == snake.Length)
                        {
                            snakeIndex = 0;
                        }

                        matrix[row][col] = snake[snakeIndex++];
                    }

                    toLeft = false;
                }
                else
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        if (snakeIndex == snake.Length)
                        {
                            snakeIndex = 0;
                        }

                        matrix[row][col] = snake[snakeIndex++];
                    }

                    toLeft = true;
                }
            }
        }

        private static void InitMatrix(out char[][] matrix)
        {
            var input = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var rows = input[0];
            var cols = input[1];

            matrix = new char[rows][];

            for (int i = 0; i < rows; i++)
            {
                matrix[i] = new char[cols];
            }
        }

        private static void PrintMatrix(ref char[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }
    }
}
