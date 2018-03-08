using System;
using System.Collections.Generic;
using System.Text;

public class Circle : Shape
{
    private double radius;

    public Circle(double radius)
    {
        this.Radius = radius;
    }

    public double Radius
    {
        get
        {
            return radius;
        }
        set
        {
            radius = value;
        }
    }

    public override double CalculateArea()
    {
        double result = Math.PI * this.Radius * this.Radius;
        return result;
    }

    public override double CalculatePerimeter()
    {
        double result = 2 * Math.PI * this.Radius;
        return result;
    }

    public sealed override string Draw()
    {
        return base.Draw() + "Circle";
    }
}

