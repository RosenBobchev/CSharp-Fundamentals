using System;
using System.Collections.Generic;
using System.Text;

public class Engineer : SpecialisedSoldier, IEngineer
{
    private ICollection<IRepair> repairs;

    public Engineer(int id, string firstName, string lastName, decimal salary, string corps)
        : base(id, firstName, lastName, salary, corps)
    {
        this.repairs = new List<IRepair>();
    }

    public IReadOnlyCollection<IRepair> Repair => (IReadOnlyCollection<IRepair>)repairs;

    public void AddRepairs(IRepair repair)
    {
        this.repairs.Add(repair);
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine(base.ToString())
                     .AppendLine($"Corps: {this.Corps}")
                     .AppendLine("Repairs:");

        foreach (var repair in this.repairs)
        {
            stringBuilder.AppendLine($"  {repair}");
        }

        return stringBuilder.ToString().TrimEnd();
    }

}
