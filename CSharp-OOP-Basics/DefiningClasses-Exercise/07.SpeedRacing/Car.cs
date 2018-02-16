using System;
using System.Collections.Generic;
using System.Text;

class Car
{
    private string model;
    private double fuelConsumption;
    private double fuelAmount;
    private double distanceTravelled;

    public Car(string model, double fuelConsumption, double fuelAmount)
    {
        this.Model = model;
        this.FuelConsumption = fuelConsumption;
        this.FuelAmount = fuelAmount;
        this.distanceTravelled = 0.0;
    }
    public string Model
    {
        get { return model; }
        set { model = value; }
    }

    public double DistanceTravelled
    {
        get { return distanceTravelled; }
        set { distanceTravelled = value; }
    }
    
    public double FuelAmount
    {
        get { return fuelAmount; }
        set { fuelAmount = value; }
    }


    public double FuelConsumption
    {
        get { return fuelConsumption; }
        set { fuelConsumption = value; }
    }

    public void Drive(double kilometers)
    {
        var neededFuel = kilometers * this.fuelConsumption;
        if (neededFuel > this.fuelAmount)
        {
            Console.WriteLine("Insufficient fuel for the drive");
            return;
        }

        this.fuelAmount -= neededFuel;
        this.distanceTravelled += kilometers;
    }
}

