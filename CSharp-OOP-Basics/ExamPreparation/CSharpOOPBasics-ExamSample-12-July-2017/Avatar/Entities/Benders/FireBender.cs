using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class FireBender : Bender
{
    public FireBender(string name, int power, double heatAggression)
        : base(name, power, heatAggression, "Fire")
    {
    }

    public override double GetPower()
    {
        return this.SecondParameter * this.Power;
    }

    public override string ToString()
    {
        return $"Fire {base.ToString()}, Heat Aggression: {this.SecondParameter:F2}";
    }
}

