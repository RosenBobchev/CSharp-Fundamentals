using System;

public abstract class Instrument : IInstrument
{
    private double wear;
    private const int MaxWear = 100;

    protected Instrument()
    {
        this.Wear = MaxWear;
    }

    public double Wear
    {
        get
        {
            return this.wear;
        }
        private set
        {
            if (value > 100)
            {
                value = 100;
            } //TODO!
            else if (value < 0)
            {
                value = 0;
            }

            this.wear = value;
        }
    }
    protected abstract int RepairAmount { get; }

    public void Repair() => this.Wear += this.RepairAmount;

    public void WearDown() => this.Wear -= this.RepairAmount;

    public bool IsBroken => this.Wear <= 0;

    public override string ToString()
    {
        var instrumentStatus = this.IsBroken ? "broken" : $"{this.Wear}%";

        return $"{this.GetType().Name} [{instrumentStatus}]";
    }
}