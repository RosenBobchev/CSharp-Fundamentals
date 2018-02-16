using System;
using System.Collections.Generic;
using System.Text;

public class DateModifier
{
    public DateTime firstDate;
    public DateTime secondDate;

    public double CalculateDifference()
    {
        return (firstDate - secondDate).TotalDays;
    }
}

