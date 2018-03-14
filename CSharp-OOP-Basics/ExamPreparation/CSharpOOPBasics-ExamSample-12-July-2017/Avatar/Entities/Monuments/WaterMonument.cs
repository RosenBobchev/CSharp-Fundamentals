using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class WaterMonument : Monument
{
    public WaterMonument(string name, int waterAffinity)
        : base(name, waterAffinity, "Water")
    {
    }

    public override double GetAffinity()
    {
        return this.Affinity;
    }

    public override string ToString()
    {
        return $"Water {base.ToString()}, Water Affinity: {this.Affinity}";
    }
}

