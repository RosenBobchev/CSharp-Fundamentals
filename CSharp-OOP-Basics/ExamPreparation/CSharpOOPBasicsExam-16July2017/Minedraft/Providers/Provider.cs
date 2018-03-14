using System;
using System.Collections.Generic;
using System.Text;

public abstract class Provider : Miner
{
    private const double MAX_ENERGY = 10000;
    private double energyOutput;
    
    protected Provider(string id, double energyOutput)
        : base(id)
    {
        this.EnergyOutput = energyOutput;
    }

    public double EnergyOutput
    {
        get
        {
            return energyOutput;
        }
        protected set
        {
            if (value < 0 || value >= MAX_ENERGY)
            {
                throw new ArgumentException($"Provider is not registered, because of it's {nameof(this.EnergyOutput)}");
            }
            energyOutput = value;
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Provider - {this.Id}");
        sb.AppendLine($"Energy Output: {this.energyOutput}");
        return sb.ToString().Trim();
    }
}

