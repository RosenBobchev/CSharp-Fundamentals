using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int numberOfCars = int.Parse(Console.ReadLine());
        List<Car> cars = new List<Car>();

        for (int i = 0; i < numberOfCars; i++)
        {
            string[] input = Console.ReadLine().Split();
            string model = input[0];
            double fuelAmount = double.Parse(input[1]);
            double fuelConsumption = double.Parse(input[2]);

            Car car = new Car(model, fuelConsumption, fuelAmount);
            cars.Add(car);
        }

        string command = string.Empty;
        while ((command = Console.ReadLine()) != "End")
        {
            var tokens = command.Split();
            string model = tokens[1];
            double kilometers = double.Parse(tokens[2]);

            var currentCar = cars.Where(c => c.Model == model).FirstOrDefault();

            if (currentCar != null)
            {
                currentCar.Drive(kilometers);
            }
        }
        Console.WriteLine(string.Join(Environment.NewLine, cars.Select(x => $"{x.Model} {x.FuelAmount:F2} {x.DistanceTravelled}")));
    }
}

