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
        this.Length = length;
        this.Width = width;
        this.Height = height;
    }

    public double Length
    {
        get { return this.length; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Length cannot be zero or negative.");
            }
            this.length = value;
        }
    }

    public double Width
    {
        get { return this.width; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Width cannot be zero or negative.");
            }
            this.length = value;
        }
    }

    public double Height
    {
        get { return this.height; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Height cannot be zero or negative.");
            }
            this.length = value;
        }
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

