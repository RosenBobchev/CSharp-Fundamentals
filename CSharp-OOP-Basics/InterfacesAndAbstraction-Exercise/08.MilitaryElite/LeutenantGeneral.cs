using System;
using System.Collections.Generic;
using System.Text;

public class LeutenantGeneral : Private, ILeutenantGeneral
{
    private ICollection<ISoldier> privates;

    public LeutenantGeneral(int id, string firstName, string lastName, decimal salary)
        : base(id, firstName, lastName, salary)
    {
        privates = new List<ISoldier>();
    }


    public IReadOnlyCollection<ISoldier> Private => (IReadOnlyCollection<ISoldier>)this.privates;

    public void AddPrivate(ISoldier soldier)
    {
        this.privates.Add(soldier);
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine(base.ToString())
                     .AppendLine("Privates:");

        foreach (var @private in this.privates)
        {
            stringBuilder.AppendLine($"  {@private}");
        }

        return stringBuilder.ToString().TrimEnd();
    }
}
