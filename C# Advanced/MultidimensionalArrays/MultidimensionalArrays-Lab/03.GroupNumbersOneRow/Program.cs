using System;
using System.Linq;

namespace _03.GroupNumbersOneRow
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine().Split(',')
                .Select(int.Parse).ToArray()
                .GroupBy(num => Math.Abs(num % 3))
                .OrderBy(row => row.Key)
                .Select(pair => string.Join(" ", pair))
                .ToList().ForEach(row => Console.WriteLine(string.Join(Environment.NewLine, row)));
        }
    }
}
