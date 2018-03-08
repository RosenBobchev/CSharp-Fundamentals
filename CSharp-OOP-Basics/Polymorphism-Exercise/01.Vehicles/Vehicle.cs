using System;
using System.Collections.Generic;
using System.Text;

public abstract class Vehicle : IVehicle
{
    public const string NEEDSREFUEL = "{0} needs refueling";

    private double fuelQuantity;
    private double fuelConsumptionPerKm;
    private double distanceDriven;

    public Vehicle(double fuelQuantity, double fuelConsumptionPerKm)
    {
        this.FuelQuantity = fuelQuantity;
        this.FuelConsumptionPerKm = fuelConsumptionPerKm;
        this.DistanceDriven = 0;
    }

    public double FuelQuantity
    {
        get { return fuelQuantity; }
        set { fuelQuantity = value; }
    }

    public virtual double FuelConsumptionPerKm
    {
        get { return fuelConsumptionPerKm; }
        set { fuelConsumptionPerKm = value; }
    }

    public double DistanceDriven
    {
        get { return distanceDriven; }
        set { distanceDriven = value; }
    }


    public void Drive(double distance)
    {
        if (this.FuelQuantity / this.FuelConsumptionPerKm < distance)
        {
            throw new InvalidOperationException(string.Format(NEEDSREFUEL, this.GetType().Name));
        }

        this.FuelQuantity -= distance * this.FuelConsumptionPerKm;
        this.DistanceDriven += distance;
    }

    public virtual void Refuel(double amount)
    {
        this.FuelQuantity += amount;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
    }
}

