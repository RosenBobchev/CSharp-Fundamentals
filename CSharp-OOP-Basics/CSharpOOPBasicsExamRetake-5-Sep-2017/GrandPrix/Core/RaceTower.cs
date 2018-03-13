using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RaceTower
{
    private readonly Dictionary<string, Driver> drivers;
    private readonly Dictionary<Driver, string> unfinishedDrivers;
    private int numberOfLaps;
    private int currentLap;
    private Weather weather;
    public Driver Winner { get; private set; }
    public int LengthOfTrack { get; set; }
    public bool IsEndOfRace { get; private set; }

    public RaceTower()
    {
        this.drivers = new Dictionary<string, Driver>();
        this.unfinishedDrivers = new Dictionary<Driver, string>();
        this.weather = Weather.Sunny;
        this.currentLap = 0;
        this.IsEndOfRace = false;
    }

    public int NumberOfLaps
    {
        get
        {
            return this.numberOfLaps;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException($"There is no time! On lap { this.currentLap }.");
            }

            this.numberOfLaps = value;
        }
    }

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        this.NumberOfLaps = lapsNumber;
        this.LengthOfTrack = trackLength;
    }

    public void RegisterDriver(List<string> commandArgs)
    {
        try
        {
            var tyreArgs = commandArgs.Skip(4).ToList();
            var carArgs = commandArgs.Skip(2).Take(2).ToList();
            var driverArgs = commandArgs.Take(2).ToList();

            var tyre = TyreFactory.Create(tyreArgs);
            var car = CarFactory.Create(carArgs, tyre);
            var driver = DriverFactory.Create(driverArgs, car);

            this.drivers.Add(driverArgs[1], driver);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void DriverBoxes(List<string> commandArgs)
    {
        var boxReasonType = commandArgs[0];
        var driverName = commandArgs[1];
        var driver = this.drivers[driverName];
        driver.TotalTime += 20;

        switch (boxReasonType)
        {
            case "Refuel":
                var fuelAmount = double.Parse(commandArgs[2]);
                driver.Car.Refuel(fuelAmount);
                break;
            case "ChangeTyres":
                var tyreArgs = commandArgs.Skip(2).ToList();
                var newTyre = TyreFactory.Create(tyreArgs);
                driver.Car.ChangeTyre(newTyre);
                break;
        }
    }

    public string CompleteLaps(List<string> commandArgs)
    {
        var result = new StringBuilder();

        var currentNumberOfLaps = int.Parse(commandArgs[0]);

        try
        {
            this.NumberOfLaps -= currentNumberOfLaps;
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }

        for (int i = 0; i < currentNumberOfLaps; i++)
        {
            SetTotalTimeOfDrivers();
            IsDriverContinuingTheRace();
            RemoveIneligibleDriversFromDict();

            this.currentLap++;
            var driversToOvertake = this.drivers.Values.OrderByDescending(d => d.TotalTime).ToList();

            CheckForOvertaking(result, driversToOvertake);
        }

        if (this.NumberOfLaps == 0)
        {
            this.IsEndOfRace = true;
            this.Winner = this.drivers.Values.OrderBy(d => d.TotalTime).FirstOrDefault();
        }

        return result.ToString().Trim();
    }

    private void CheckForOvertaking(StringBuilder result, List<Driver> driversToOvertake)
    {
        for (int i = 0; i < driversToOvertake.Count - 1; i++)
        {
            var firstDriver = driversToOvertake[i];
            var secondDriver = driversToOvertake[i + 1];
            var timeForFirstDriver = firstDriver.TotalTime;
            var timeForSecondDriver = secondDriver.TotalTime;
            var diff = Math.Abs(timeForFirstDriver - timeForSecondDriver);
            var intervalForOvertaking = 2;

            bool IsCrashed = CheckForSpecialConditions(firstDriver, ref intervalForOvertaking);

            if (diff <= intervalForOvertaking)
            {
                if (IsCrashed)
                {
                    this.unfinishedDrivers.Add(firstDriver, "Crashed");
                    foreach (var crashedDriver in this.unfinishedDrivers)
                    {
                        if (this.drivers.ContainsKey(crashedDriver.Key.Name))
                        {
                            drivers.Remove(crashedDriver.Key.Name);
                        }
                    }

                    continue;
                }

                PrintOvertakenDrivers(result, firstDriver, secondDriver, intervalForOvertaking);
            }
        }
    }

    private bool CheckForSpecialConditions(Driver firstDriver, ref int intervalForOvertaking)
    {
        bool IsCrashed = false;

        if (firstDriver.GetType().Name == "Aggressive" 
            && firstDriver.Car.Tyre.GetType().Name == "UltrasoftTyre")
        {
            intervalForOvertaking = 3;
            if (this.weather == Weather.Foggy)
            {
                IsCrashed = true;
            }
        }

        if (firstDriver.GetType().Name == "EnduranceDriver" 
            && firstDriver.Car.Tyre.GetType().Name == "HardTyre")
        {
            intervalForOvertaking = 3;
            if (this.weather == Weather.Rainy)
            {
                IsCrashed = true;
            }
        }

        return IsCrashed;
    }

    private void PrintOvertakenDrivers(StringBuilder result, Driver firstDriver, Driver secondDriver, int intervalForOvertaking)
    {
        firstDriver.TotalTime -= intervalForOvertaking;
        secondDriver.TotalTime -= intervalForOvertaking;

        result.AppendLine($"{firstDriver.Name} has overtaken {secondDriver.Name} on lap {this.currentLap}");
    }

    private void RemoveIneligibleDriversFromDict()
    {
        foreach (var crashDriver in this.unfinishedDrivers)
        {
            if (this.drivers.ContainsKey(crashDriver.Key.Name))
            {
                this.drivers.Remove(crashDriver.Key.Name);
            }
        }
    }

    private void IsDriverContinuingTheRace()
    {
        foreach (var driver in this.drivers.Values)
        {
            try
            {
                driver.ReduceFuelAmount(this.LengthOfTrack);
                driver.Car.Tyre.ReduceDegradation();
            }
            catch (ArgumentException ex)
            {
                this.unfinishedDrivers.Add(driver, ex.Message);
            }
        }
    }

    private void SetTotalTimeOfDrivers()
    {
        foreach (var driver in this.drivers.Values)
        {
            driver.TotalTime += 60 / (this.LengthOfTrack / driver.Speed);
        }
    }

    public string GetLeaderboard()
    {
        var result = new StringBuilder();
        var counter = 1;

        result.AppendLine($"Lap {this.currentLap}/{this.currentLap + this.NumberOfLaps}");

        foreach (var driver in this.drivers.Values.OrderBy(d => d.TotalTime))
        {
            result.AppendLine($"{counter++} {driver.Name} {driver.TotalTime:F3}");
        }

        var crashedDrivers = this.unfinishedDrivers.Reverse();
        foreach (var driver in crashedDrivers)
        {
            result.AppendLine($"{counter++} {driver.Key.Name} {driver.Value}");
        }

        return result.ToString().Trim();
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        var weatherToChange = commandArgs[0];
        this.weather = (Weather)Enum.Parse(typeof(Weather), weatherToChange);
    }
}
