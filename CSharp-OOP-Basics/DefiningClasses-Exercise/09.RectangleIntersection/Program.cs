using System;
using System.Collections.Generic;
using System.Linq;

public class Program
 {
     static void Main(string[] args)
     {
        var input = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

        int rectanglesInput = int.Parse(input[0]);
        int numberOfChecks = int.Parse(input[1]);
        List<Rectangle> rectangles = new List<Rectangle>(rectanglesInput);

        while (rectangles.Count < rectanglesInput)
        {
            var info = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string id = info[0];
            double width = double.Parse(info[1]);
            double height = double.Parse(info[2]);
            double leftX = double.Parse(info[3]);
            double leftY = double.Parse(info[4]);

            rectangles.Add(new Rectangle(id, width, height, leftX, leftY));
        }

        while (numberOfChecks > 0)
        {
            var pairs = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            var firstRectangle = rectangles.Where(r => r.Id == pairs[0]).FirstOrDefault();
            var secondRectangle = rectangles.Where(r => r.Id == pairs[1]).FirstOrDefault();

            if (firstRectangle.Intersect(secondRectangle))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }

            numberOfChecks--;
        }
     }
 }

