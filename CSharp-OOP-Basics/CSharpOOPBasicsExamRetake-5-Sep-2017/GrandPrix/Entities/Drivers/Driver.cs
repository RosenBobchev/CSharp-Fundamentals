using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Driver
{
    private string name;
    private double totalTime;
    private Car car;

    protected Driver(string name, Car car, double consumptionPerKm)
    {
        this.Name = name;
        this.TotalTime = 0;
        this.Car = car;
        this.ConsumptionPerKm = consumptionPerKm;
    }

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public double TotalTime
    {
        get { return this.totalTime; }
        set { this.totalTime = value; }
    }

    public Car Car
    {
        get { return this.car; }
        set {this.car = value; }
    }

    public double ConsumptionPerKm { get; protected set; }

    public virtual double Speed => (this.Car.HorsePower + this.Car.Tyre.Degradation) / this.Car.FuelAmount;

    public virtual void ReduceFuelAmount(int length)
    {
        this.Car.ReduceFuel(length, this.ConsumptionPerKm);
    }
}

