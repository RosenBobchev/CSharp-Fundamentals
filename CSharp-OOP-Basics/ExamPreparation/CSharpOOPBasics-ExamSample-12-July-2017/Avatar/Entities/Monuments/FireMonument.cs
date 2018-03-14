using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class FireMonument : Monument
{
    public FireMonument(string name, int fireAffinity)
        : base(name, fireAffinity, "Fire")
    {
    }

    public override double GetAffinity()
    {
        return this.Affinity;
    }

    public override string ToString()
    {
        return $"Fire {base.ToString()}, Fire Affinity: {this.Affinity}";
    }
}

