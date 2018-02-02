using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.RubiksMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var rowAndCol = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            var r = rowAndCol[0];
            var c = rowAndCol[1];

            InitMatrix(out var matrix, r, c);
            InitMatrix(out var originalMatrix, r, c);

            var numberOfCommands = int.Parse(Console.ReadLine());

            while (numberOfCommands > 0)
            {
                var input = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                var command = input[1];
                var rowOrCol = int.Parse(input[0]);
                var moves = int.Parse(input[2]);

                switch (command)
                {

                    case "up":
                        ColumnsMove(ref matrix, rowOrCol, moves, command);
                        break;
                    case "down":
                        ColumnsMove(ref matrix, rowOrCol, moves, command);
                        break;
                    case "left":
                        RowsMove(ref matrix, rowOrCol, moves, command);
                        break;
                    case "right":
                        RowsMove(ref matrix, rowOrCol, moves, command);
                        break;
                }

                numberOfCommands--;
            }

            Verification(ref originalMatrix, ref matrix);
        }

        private static void Verification(ref int[][] originalMatrix, ref int[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == originalMatrix[row][col])
                    {
                        Console.WriteLine("No swap required");
                        continue;
                    }

                    var searchedElement = originalMatrix[row][col];
                    for (int r = 0; r < matrix.Length; r++)
                    {
                        for (int c = 0; c < matrix[r].Length; c++)
                        {
                            if (matrix[r][c] == searchedElement)
                            {
                                matrix[r][c] = matrix[row][col];
                                matrix[row][col] = searchedElement;
                                Console.WriteLine($"Swap ({row}, {col}) with ({r}, {c})");
                            }
                        }
                    }
                }
            }
        }

        private static void RowsMove(ref int[][] matrix, int row, int moves, string command)
        {
            moves = moves % matrix[row].Length;

            if (command == "left")
            {
                for (int r = 0; r < moves; r++)
                {
                    var fistElement = matrix[row][0];

                    for (int col = 0; col < matrix[row].Length - 1; col++)
                    {
                        matrix[row][col] = matrix[row][col + 1];
                    }

                    matrix[row][matrix[row].Length - 1] = fistElement;
                }
            }
            else if (command == "right")
            {
                for (int r = 0; r < moves; r++)
                {
                    var lastElement = matrix[row][matrix[row].Length - 1];

                    for (int col = matrix[row].Length - 1; col > 0; col--)
                    {
                        matrix[row][col] = matrix[row][col - 1];
                    }

                    matrix[row][0] = lastElement;
                }
            }
        }

        private static void ColumnsMove(ref int[][] matrix, int column, int moves, string command)
        {
            moves = moves % matrix[0].Length;

            if (command == "up")
            {
                for (int i = 0; i < moves; i++)
                {
                    var firstElement = matrix[0][column];

                    for (int row = 0; row < matrix.Length - 1; row++)
                    {
                        matrix[row][column] = matrix[row + 1][column];
                    }

                    matrix[matrix.Length - 1][column] = firstElement;
                }
            }
            else if (command == "down")
            {
                for (int i = 0; i < moves; i++)
                {
                    var lastElement = matrix[matrix.Length - 1][column];

                    for (int row = matrix.Length - 1; row > 0; row--)
                    {
                        matrix[row][column] = matrix[row - 1][column];
                    }

                    matrix[0][column] = lastElement;
                }
            }
        }

        private static void InitMatrix(out int[][] matrix, int r, int c)
        {
            var count = 1;
            matrix = new int[r][];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new int[c];
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = count++;
                }
            }
        }
    }
}
