using System;
using System.Collections.Generic;
using System.Text;

public class Square
{
    public static void DrawSquare(int size)
    {
        var sb = new StringBuilder();
        for (int i = 0; i < size; i++)
        {
            if (i == 0 || i == size - 1)
            {
                sb.AppendLine($"|{new string('-', size)}|");
                continue;
            }

            sb.AppendLine($"|{new string(' ', size)}|");
        }

        Console.Write(sb);
    }
}

