using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class WaterBender : Bender
{
    public WaterBender(string name, int power, double waterClarity)
        : base(name, power, waterClarity, "Water")
    {
    }

    public override double GetPower()
    {
        return this.SecondParameter * this.Power;
    }

    public override string ToString()
    {
        return $"Water {base.ToString()}, Water Clarity: {this.SecondParameter:F2}";
    }
}

