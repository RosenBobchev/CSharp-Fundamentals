using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        var cars = GetCars();

        string command = Console.ReadLine();

        List<Car> neededCars = new List<Car>();
        if (command == "fragile")
        {
            neededCars = cars.Where(c => c.Cargo.Type.Equals(command) && c.Tires.Any(t => t.Pressure < 1)).ToList();
        }
        else if(command == "flamable")
        {
            neededCars = cars.Where(c => c.Cargo.Type.Equals(command) && c.Engine.Power > 250).ToList();
        }

        foreach (var car in neededCars)
        {
            Console.WriteLine(car.Model);
        }
    }

    private static List<Car> GetCars()
    {
        List<Car> cars = new List<Car>();
        int numberOfCars = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfCars; i++)
        {
            //<Model> <EngineSpeed int> <EnginePower int> <CargoWeight int> <CargoType> <Tire1Pressure double> <Tire1Age int> <Tire2Pressure double> <Tire2Age int> <Tire3Pressure double> <Tire3Age int> <Tire4Pressure double> <Tire4Age int>” 
            var info = Console.ReadLine().Split();
            string model = info[0];
            int power = int.Parse(info[1]);
            int speed = int.Parse(info[2]);
            var engine = new Engine(power, speed);
            int weight = int.Parse(info[3]);
            string type = info[4];
            var cargo = new Cargo(weight, type);
            var tires = new Tire[]
            {
                new Tire(int.Parse(info[6]), double.Parse(info[5])),
                new Tire(int.Parse(info[8]), double.Parse(info[7])),
                new Tire(int.Parse(info[10]), double.Parse(info[9])),
                new Tire(int.Parse(info[12]), double.Parse(info[11])),
            };

            cars.Add(new Car(model, engine, cargo, tires));
        }

        return cars;
    }
}

