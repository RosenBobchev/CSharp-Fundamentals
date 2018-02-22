using System;

public class Program
{
    static void Main(string[] args)
    {

        double length = double.Parse(Console.ReadLine());
        double width = double.Parse(Console.ReadLine());
        double height = double.Parse(Console.ReadLine());
        try
        {
            var box = new Box(length, width, height);
            double surfaceResult = box.CalculateSurfaceArea(length, width, height);
            double lateralResult = box.CalculateLateralArea(length, width, height);
            double volumeResult = box.CalculateVolume(length, width, height);

            Console.WriteLine($"Surface Area - {surfaceResult:F2}");
            Console.WriteLine($"Lateral Surface Area - {lateralResult:F2}");
            Console.WriteLine($"Volume - {volumeResult:F2}");

        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }

    }
}

