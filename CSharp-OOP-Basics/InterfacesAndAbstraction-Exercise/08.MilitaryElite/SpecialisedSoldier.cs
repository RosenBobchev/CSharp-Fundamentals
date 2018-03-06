using System;
using System.Collections.Generic;
using System.Text;

public class SpecialisedSoldier : Private, ISpecialisedSoldier
{
    public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corps)
        : base(id, firstName, lastName, salary)
    {
        ParseCorps(corps);
    }

    private void ParseCorps(string corps)
    {
        bool validCorps = Enum.TryParse(typeof(Corps), corps, out object result);
        if (validCorps)
        {
            this.Corps = (Corps)result;
        }
        else
        {
            throw new ArgumentException("Invalid Corps");
        }
    }

    public Corps Corps { get; private set; }
}
