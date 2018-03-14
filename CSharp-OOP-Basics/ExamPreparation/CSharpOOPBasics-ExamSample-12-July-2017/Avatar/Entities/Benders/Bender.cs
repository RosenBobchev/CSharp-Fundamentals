using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Bender
{
    private string name;
    private int power;
    private double secondParameter;
    private string type;

    protected Bender(string name, int power, double secondParameter, string type)
    {
        this.Name = name;
        this.Power = power;
        this.SecondParameter = secondParameter;
        this.Type = type;
    }
    
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Power
    {
        get { return power; }
        set { power = value; }
    }

    public string Type
    {
        get { return type; }
        set { type = value; }
    }

    public double SecondParameter
    {
        get { return secondParameter; }
        set { secondParameter = value; }
    }

    public abstract double GetPower();

    public override string ToString()
    {
        return $"Bender: { this.Name}, Power: { this.Power}";
    }
}

