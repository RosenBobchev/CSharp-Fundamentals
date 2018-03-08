using System;
using System.Collections.Generic;
using System.Text;

public interface IVehicle
{
    double FuelQuantity { get; }
    double FuelConsumptionPerKm { get; }

    void Drive(double distance);
    void Refuel(double amount);
}
