using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class EnduranceDriver : Driver
{
    private const double FuelConsumption = 1.5;

    public EnduranceDriver(string name, Car car)
        : base(name, car, FuelConsumption)
    {
    }
}

