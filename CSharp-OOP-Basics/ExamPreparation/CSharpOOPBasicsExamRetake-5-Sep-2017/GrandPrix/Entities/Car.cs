using System;

public class Car
{
    private const int MAX_TANK = 160;
    private int horsePower;
    private double fuelAmount;
    private Tyre tyre;

    public Car(int horsePower, double fuelAmount, Tyre tyre)
    {
        this.HorsePower = horsePower;
        this.FuelAmount = fuelAmount;
        this.Tyre = tyre;
    }

    public int HorsePower
    {
        get { return horsePower; }
        set { horsePower = value; }
    }

    public double FuelAmount
    {
        get
        {
            return fuelAmount;
        }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException("Out of fuel");
            }
            this.fuelAmount = value > MAX_TANK ? MAX_TANK : value;
        }
    }

    public Tyre Tyre
    {
        get { return tyre; }
        protected set { tyre = value; }
    }

    public void ChangeTyre(Tyre tyre)
    {
        this.Tyre = tyre;
    }

    public void ReduceFuel(int length, double fuelConsumption)
    {
        this.FuelAmount = this.FuelAmount - (length * fuelConsumption);
    }

    public void Refuel(double amount)
    {
        this.FuelAmount += amount;
    }
}

