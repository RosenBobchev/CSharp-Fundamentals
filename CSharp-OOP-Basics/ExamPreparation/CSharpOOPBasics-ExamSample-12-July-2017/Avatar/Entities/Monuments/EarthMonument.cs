using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class EarthMonument : Monument
{
    public EarthMonument(string name, int earthAffinity)
        : base(name, earthAffinity, "Earth")
    {
    }

    public override double GetAffinity()
    {
        return this.Affinity;
    }

    public override string ToString()
    {
        return $"Earth {base.ToString()}, Earth Affinity: {this.Affinity}";
    }
}

