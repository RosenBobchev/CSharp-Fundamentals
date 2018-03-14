using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AggressiveDriver : Driver
{
    private const double FuelConsumption = 2.7;

    public AggressiveDriver(string name, Car car)
        : base(name, car, FuelConsumption)
    {
    }

    public override double Speed => base.Speed * 1.3;
}