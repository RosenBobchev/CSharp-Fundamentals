using System;

public class Program
{
    static void Main(string[] args)
    {
        string figure = Console.ReadLine();

        if (figure.Equals("Square"))
        {
            int size = int.Parse(Console.ReadLine());

            Square.DrawSquare(size);
        }
        else
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());

            Rectangle.DrawRectangle(width, length);
        }
    }
}

