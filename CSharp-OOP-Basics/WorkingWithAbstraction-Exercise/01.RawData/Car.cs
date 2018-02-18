using System;
using System.Collections.Generic;
using System.Text;

public class Car
{
    public Car(string model, int engineSpeed, int enginePower, int cargoWeight, string cargoType, List<Tire> tires)
    {
        this.Model = model;
        this.EngineSpeed = engineSpeed;
        this.EnginePower = enginePower;
        this.CargoWeight = cargoWeight;
        this.CargoType = cargoType;
        this.tires = tires;
    }
    public string Model { get; set; }
    public int EngineSpeed { get; set; }
    public int EnginePower { get; set; }
    public int CargoWeight { get; set; }
    public string CargoType { get; set; }
    public List<Tire> tires;
}
