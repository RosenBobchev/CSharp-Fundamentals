using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int dimensions = int.Parse(Console.ReadLine());
            char[][] matrix = new char[dimensions][];

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine().ToCharArray();
            }

            var dict = new Dictionary<string, int>();
            int removedKnights = 0;

            while (true)
            {
                for (int row = 0; row < matrix.Length; row++)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        if (matrix[row][col] == 'K')
                        {
                            CheckPosition(dict, row, col, matrix);
                        }
                    }
                }

                string maxPosition = "";
                foreach (var item in dict.Where(x => x.Value != 0).OrderByDescending(x => x.Value))
                {
                    maxPosition = item.Key;
                    break;
                }

                if (maxPosition != string.Empty)
                {
                    removedKnights++;
                    dict.Remove(maxPosition);
                    int[] rowAndCol = maxPosition.Split(new string[] { " " },
                        StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                    matrix[rowAndCol[0]][rowAndCol[1]] = '0';
                }
                else
                {
                    Console.WriteLine(removedKnights);
                    return;
                }
            }
        }

        private static void CheckPosition(Dictionary<string, int> dict, int row, int col, char[][] matrix)
        {
            int count = 0;

            if (row - 2 >= 0 && col - 1 >= 0)
            {
                if (matrix[row - 2][col - 1] == 'K')
                {
                    count++;
                }
            }
            if (row - 1 >= 0 && col - 2 >= 0)
            {
                if (matrix[row - 1][col - 2] == 'K')
                {
                    count++;
                }
            }
            if (row + 1 < matrix.Length && col - 2 >= 0)
            {
                if (matrix[row + 1][col - 2] == 'K')
                {
                    count++;
                }
            }
            if (row + 2 < matrix.Length && col - 1 >= 0)
            {
                if (matrix[row + 2][col - 1] == 'K')
                {
                    count++;
                }
            }
            if (row - 2 >= 0 && col + 1 < matrix.Length)
            {
                if (matrix[row - 2][col + 1] == 'K')
                {
                    count++;
                }
            }
            if (row - 1 >= 0 && col + 2 < matrix.Length)
            {
                if (matrix[row - 1][col + 2] == 'K')
                {
                    count++;
                }
            }
            if (row + 1 < matrix.Length && col + 2 < matrix.Length)
            {
                if (matrix[row + 1][col + 2] == 'K')
                {
                    count++;
                }
            }
            if (row + 2 < matrix.Length && col + 1 < matrix.Length)
            {
                if (matrix[row + 2][col + 1] == 'K')
                {
                    count++;
                }
            }

            string position = $"{row} {col}";
            if (count != 0)
            {
                if (dict.ContainsKey(position))
                {
                    dict[position] = count;
                }
                else
                {
                    dict.Add(position, count);
                }
            }
            else if (dict.ContainsKey(position))
            {
                dict[position] = count;
            }
        }
    }
}
