using System;
using System.Collections.Generic;
using System.Text;

public abstract class Harvester : Miner
{
    private const double MAX_ENERGY = 20000;
    private double oreOutput;
    private double energyRequirement;

    protected Harvester(string id, double oreOutput, double energyRequirement) : base(id)
    {
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;

    }

    public double OreOutput
    {
        get
        {
            return oreOutput;
        }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException($"Harvester is not registered, because of it's {nameof(this.OreOutput)}");
            }
            oreOutput = value;
        }
    }

    public double EnergyRequirement
    {
        get
        {
            return energyRequirement;
        }
        protected set
        {
            if (value < 0 || value > MAX_ENERGY)
            {
                throw new ArgumentException($"Harvester is not registered, because of it's {nameof(this.EnergyRequirement)}");
            }
            energyRequirement = value;
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Harvester - {this.Id}");
        sb.AppendLine($"Ore Output: {this.OreOutput}");
        sb.AppendLine($"Energy Requirement: {this.EnergyRequirement}");
        return sb.ToString().Trim();

    }
}

