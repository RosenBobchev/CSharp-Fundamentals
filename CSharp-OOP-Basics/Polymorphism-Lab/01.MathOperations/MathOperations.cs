using System;
using System.Collections.Generic;
using System.Text;

public class MathOperations
{
    public int Add(int a, int b)
    {
        int result = a + b;
        return result;
    }

    public double Add(double a, double b, double c)
    {
        double result = a + b + c;
        return result;
    }

    public decimal Add(decimal a, decimal b, decimal c)
    {
        decimal result = a + b + c;
        return result;
    }
}

