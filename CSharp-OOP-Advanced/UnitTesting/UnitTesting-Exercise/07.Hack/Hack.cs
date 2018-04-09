using System;
using System.Collections.Generic;
using System.Text;

public class Hack : IMath
{
    public Hack()
    {
        Value = 0.0;
    }

    public double Value { get; set; }

    public int ReturnAbsValue(double i)
    {
        this.Value = Math.Abs(i);
        return (int)this.Value;
    }

    public int ReturnFloorValue(double i)
    {
        this.Value = Math.Floor(i);
        return (int)this.Value;
    }
}