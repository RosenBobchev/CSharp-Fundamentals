using System;
using System.Collections.Generic;
using System.Text;

public class Rectangle : Shape
{
    private double height;
    private double width;

    public Rectangle(double height, double width)
    {
        this.Height = height;
        this.Width = width;
    }

    public double Height
    {
        get
        {
            return height;
        }
        set
        {
            height = value;
        }
    }

    public double Width
    {
        get
        {
            return width;
        }
        set
        {
            width = value;
        }
    }
    
    public override double CalculateArea()
    {
        double result = this.Height * this.Width;
        return result;
    }

    public override double CalculatePerimeter()
    {
        double result = this.Height * 2 + this.Width * 2;
        return result;
    }

    public sealed override string Draw()
    {
        return base.Draw() + "Rectangle";
    }
}
