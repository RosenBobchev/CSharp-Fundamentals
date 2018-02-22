using System;
using System.Collections.Generic;
using System.Text;

public class Box
{
    private double length;
    private double width;
    private double height;

    public Box(double length, double width, double height)
    {
        this.length = length;
        this.width = width;
        this.height = height;
    }

    public double CalculateSurfaceArea(double length, double width, double height)
    {
        double result = 2 * (length * width) + 2 * (length * height) + 2 * (width * height);
        return result;
    }

    public double CalculateLateralArea(double length, double width, double height)
    {
        double result = 2 * (length * height) + 2 * (width * height);
        return result;
    }

    public double CalculateVolume(double length, double width, double height)
    {
        double result = length * width * height;
        return result;
    }
}

