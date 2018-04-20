using System;

public abstract class Provider : IProvider
{
    private const int InitialDurability = 1000;
    private const int DurabilityDecrease = 100;

    private double energyOutput;

    protected Provider(int id, double energyOutput)
    {
        this.ID = id;
        this.EnergyOutput = energyOutput;
        this.Durability = InitialDurability;
    }

    public double EnergyOutput { get; protected set; }

    public int ID { get; }

    public virtual double Durability { get; protected set; }

    public void Broke()
    {
        this.Durability -= DurabilityDecrease;
        if (this.Durability < 0)
        {
            throw new Exception("Provider is broken!");
        }
    }

    public double Produce()
    {
        return this.EnergyOutput;
    }

    public void Repair(double value)
    {
        this.Durability += value;
    }
}