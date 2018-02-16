using System;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        var coords = Console.ReadLine().Split().Select(int.Parse).ToList();
        var rectangle = new Rectangle(coords[0], coords[1], coords[2], coords[3]);
        var pointsCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < pointsCount; i++)
        {
            var pointsCoords = Console.ReadLine().Split().Select(int.Parse).ToList();
            var point = new Point(pointsCoords[0], pointsCoords[1]);
            var contains = rectangle.Contains(point);

            Console.WriteLine(contains);
        }
    }
}

