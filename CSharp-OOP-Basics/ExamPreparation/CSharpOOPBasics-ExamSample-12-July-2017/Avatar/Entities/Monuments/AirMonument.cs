using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AirMonument : Monument
{
    public AirMonument(string name, int airAffinity)
        : base(name, airAffinity, "Air")
    {
    }

    public override double GetAffinity()
    {
        return this.Affinity;
    }

    public override string ToString()
    {
        return $"Air {base.ToString()}, Air Affinity: {this.Affinity}";
    }
}

