using System;
using System.Collections.Generic;
using System.Text;

public class PressureProvider : Provider
{
    public PressureProvider(string id, double energyOutput) 
        : base(id, energyOutput)
    {
        this.EnergyOutput = this.EnergyOutput + (this.EnergyOutput * 50 / 100);
    }
    
    public override string ToString()
    {
        return $"Pressure {base.ToString().Trim()}";
    }
}

