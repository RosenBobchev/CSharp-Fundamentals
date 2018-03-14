using System;
using System.Collections.Generic;
using System.Text;

public class HammerHarvester : Harvester
{
    public HammerHarvester(string id, double oreOutput, double energyRequirement) 
        : base(id, oreOutput, energyRequirement)
    {
        this.OreOutput = this.OreOutput + (this.OreOutput * 200 / 100);
        this.EnergyRequirement = this.EnergyRequirement + (this.EnergyRequirement * 100 / 100);
    }

    public override string ToString()
    {
        return $"Hammer {base.ToString().Trim()}";
    }
}

