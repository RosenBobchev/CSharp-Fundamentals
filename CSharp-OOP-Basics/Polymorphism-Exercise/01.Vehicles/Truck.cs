using System;
using System.Collections.Generic;
using System.Text;

public class Truck : Vehicle
{
    public Truck(double fuelQuantity, double fuelConsumptionPerKm) : base(fuelQuantity, fuelConsumptionPerKm)
    {
    }

    public override double FuelConsumptionPerKm => base.FuelConsumptionPerKm + 1.6;

    public override void Refuel(double amount)
    {
        this.FuelQuantity += amount * 0.95;
    }
}
