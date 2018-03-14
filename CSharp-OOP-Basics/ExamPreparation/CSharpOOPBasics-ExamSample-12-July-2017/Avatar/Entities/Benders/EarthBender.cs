using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class EarthBender : Bender
{
    public EarthBender(string name, int power, double groundSaturation)
        : base(name, power, groundSaturation, "Earth")
    {
    }


    public override double GetPower()
    {
        return this.SecondParameter * this.Power;
    }

    public override string ToString()
    {
        return $"Earth {base.ToString()}, Ground Saturation: {this.SecondParameter:F2}";
    }
}

