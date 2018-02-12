using System;

namespace _02.CubicRube
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());

            var rube = new long[n, n, n];
            long totalSum = 0;
            long changedCellsCounter = 0;

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Analyze")
            {
                var tokens = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                long row = long.Parse(tokens[0]);
                long col = long.Parse(tokens[1]);
                long depth = long.Parse(tokens[2]);
                long particles = long.Parse(tokens[3]);

                if (row < n && col < n && depth < n && row >= 0 && col >= 0 && depth >= 0 && particles != 0)
                {
                    if (rube[row, col, depth] == 0)
                    {
                        rube[row, col, depth] = particles;
                        changedCellsCounter++;
                        totalSum += particles;
                    }
                }
            }

            Console.WriteLine(totalSum);
            Console.WriteLine(rube.LongLength - changedCellsCounter);
        }
    }
}
