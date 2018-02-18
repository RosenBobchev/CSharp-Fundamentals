using System;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        int[] dimensions = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        int row = dimensions[0];
        int col = dimensions[1];

        int[,] matrix = new int[row, col];

        int value = 0;
        for (int rows = 0; rows < row; rows++)
        {
            for (int cols = 0; cols < col; cols++)
            {
                matrix[rows, cols] = value++;
            }
        }

        string command = Console.ReadLine();
        long sum = 0;
        while (command != "Let the Force be with you")
        {
            int[] tokens = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] input = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int tokensRow = input[0];
            int tokensCol = input[1];

            while (tokensRow >= 0 && tokensCol >= 0)
            {
                if (tokensRow >= 0 && tokensRow < matrix.GetLength(0) && tokensCol >= 0 && tokensCol < matrix.GetLength(1))
                {
                    matrix[tokensRow, tokensCol] = 0;
                }
                tokensRow--;
                tokensCol--;
            }

            int inputRow = tokens[0];
            int inputCol = tokens[1];

            while (inputRow >= 0 && inputCol < matrix.GetLength(1))
            {
                if (inputRow >= 0 && inputRow < matrix.GetLength(0) && inputCol >= 0 && inputCol < matrix.GetLength(1))
                {
                    sum += matrix[inputRow, inputCol];
                }

                inputCol++;
                inputRow--;
            }

            command = Console.ReadLine();
        }

        Console.WriteLine(sum);
    }
}

