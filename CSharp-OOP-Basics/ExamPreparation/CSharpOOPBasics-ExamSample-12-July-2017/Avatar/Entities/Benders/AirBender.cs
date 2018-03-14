using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AirBender : Bender
{
    public AirBender(string name, int power, double aerialIntegrity)
    : base(name, power, aerialIntegrity, "Air")
    {
    }

    public override double GetPower()
    {
        return this.SecondParameter * this.Power;
    }

    public override string ToString()
    {
        return $"Air {base.ToString()}, Aerial Integrity: {this.SecondParameter:F2}";
    }
}

