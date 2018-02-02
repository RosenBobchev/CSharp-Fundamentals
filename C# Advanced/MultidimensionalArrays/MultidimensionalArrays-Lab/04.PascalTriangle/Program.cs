using System;

namespace _04.PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            var height = int.Parse(Console.ReadLine());
            long[][] triangle = new long[height][];
            long currentWidht = 1;

            for (int currentHeight = 0; currentHeight < height; currentHeight++)
            {
                triangle[currentHeight] = new long[currentHeight + 1];
                triangle[currentHeight][0] = 1;
                triangle[currentHeight][currentHeight] = 1;

                if (currentHeight >= 2)
                {
                    for (int widthCounter = 1; widthCounter < currentHeight; widthCounter++)
                    {
                        triangle[currentHeight][widthCounter] =
                            triangle[currentHeight - 1][widthCounter - 1] +
                            triangle[currentHeight - 1][widthCounter];
                    }
                }
            }

            for (int rows = 0; rows < triangle.Length; rows++)
            {
                for (int columns = 0; columns < triangle[rows].Length; columns++)
                {
                    Console.Write(triangle[rows][columns] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
