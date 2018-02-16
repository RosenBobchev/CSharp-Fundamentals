using System;
using System.Collections.Generic;
using System.Text;

public class Rectangle
{
    private string id;
    private double width;
    private double height;
    private double leftX;
    private double leftY;

    public Rectangle(string id, double width, double height, double leftX, double leftY)
    {
        this.id = id;
        this.width = Math.Abs(width);
        this.height = Math.Abs(height);
        this.leftX = Math.Abs(leftX);
        this.leftY = Math.Abs(leftY);
    }
    public string Id
    {
        get { return id; }
        set { id = value; }
    }

    public double Width
    {
        get { return width; }
        set { width = value; }
    }

    public double Height
    {
        get { return height; }
        set { height = value; }
    }

    public double LeftY
    {
        get { return leftY; }
        set { leftY = value; }
    }
    
    public double LeftX
    {
        get { return leftX; }
        set { leftX = value; }
    }
    
    public bool Intersect(Rectangle rectangle)
    {
        return rectangle.leftX + rectangle.width >= this.leftX &&
                rectangle.leftX <= this.leftX + this.width &&
                rectangle.leftY >= this.leftY - this.height &&
                rectangle.leftY - rectangle.height <= this.leftY;
    }
}

