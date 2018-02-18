using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        List<Car> cars = new List<Car>();
        int lines = int.Parse(Console.ReadLine());
        for (int i = 0; i < lines; i++)
        {
            string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string model = parameters[0];
            int engineSpeed = int.Parse(parameters[1]);
            int enginePower = int.Parse(parameters[2]);
            int cargoWeight = int.Parse(parameters[3]);
            string cargoType = parameters[4];
            var tires = new List<Tire>
            {
                new Tire(int.Parse(parameters[6]), double.Parse(parameters[5])),
                new Tire(int.Parse(parameters[8]), double.Parse(parameters[7])),
                new Tire(int.Parse(parameters[10]), double.Parse(parameters[9])),
                new Tire(int.Parse(parameters[12]), double.Parse(parameters[11])),
            };

            cars.Add(new Car(model, engineSpeed, enginePower, cargoWeight, cargoType, tires));
        }

        string command = Console.ReadLine();
        if (command == "fragile")
        {
            List<string> fragile = cars
                .Where(x => x.CargoType == "fragile" && x.tires.Any(y => y.Pressure < 1))
                .Select(x => x.Model)
                .ToList();

            Console.WriteLine(string.Join(Environment.NewLine, fragile));
        }
        else
        {
            List<string> flamable = cars
                .Where(x => x.CargoType == "flamable" && x.EnginePower > 250)
                .Select(x => x.Model)
                .ToList();

            Console.WriteLine(string.Join(Environment.NewLine, flamable));
        }
    }
}

