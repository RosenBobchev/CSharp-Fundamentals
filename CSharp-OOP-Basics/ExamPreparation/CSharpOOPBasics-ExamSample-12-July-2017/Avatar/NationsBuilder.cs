using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class NationsBuilder
{
    private Dictionary<string, Nation> nations;
    private List<string> warsArchive;

    public NationsBuilder()
    {
        this.nations = new Dictionary<string, Nation>()
        {
            {"Air", new Nation() },
            {"Fire", new Nation() },
            {"Earth", new Nation() },
            {"Water", new Nation() }
        };
        this.warsArchive = new List<string>();
    }

    public void AssignBender(List<string> benderArgs)
    {
        var benderType = benderArgs[0];
        Bender newBender = BenderFactory.CreateBender(benderArgs);

        nations[benderType].AddBender(newBender);
    }
    public void AssignMonument(List<string> monumentArgs)
    {
        var monumentType = monumentArgs[0];
        Monument newMonument = MonumentFactory.CreateMonument(monumentArgs);

        nations[monumentType].AddMonument(newMonument);
    }
    public string GetStatus(string nationsType)
    {
        var sb = new StringBuilder();

        sb.AppendLine($"{nationsType} Nation")
           .Append(this.nations[nationsType]);


        return sb.ToString();
    }

    public void IssueWar(string nationsType)
    {
        var orderedNations = nations.Values.OrderByDescending(n => n.GetTotalPower()).Skip(1).ToList();

        foreach (var nation in orderedNations)
        {
            nation.ClearDefeatedArmy();
        }

        this.warsArchive.Add($"War {this.warsArchive.Count + 1} issued by {nationsType}");
    }

    public string GetWarsRecord()
    {
        return string.Join(Environment.NewLine, this.warsArchive);
    }
}

