using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Commando : SpecialisedSoldier, ICommando
{
    private ICollection<IMission> missions;

    public Commando(int id, string firstName, string lastName, decimal salary, string corps)
        : base(id, firstName, lastName, salary, corps)
    {
        this.missions = new List<IMission>();
    }

    public IReadOnlyCollection<IMission> Missions => (IReadOnlyCollection<IMission>)missions;

    public void AddMissions(IMission mission)
    {
        this.missions.Add(mission);
    }

    public void CompleteMission(string missionCodeName)
    {
        IMission mission = this.missions.FirstOrDefault(x => x.CodeName == missionCodeName);

        if (mission != null)
        {
            mission.Complete();
        }
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine(base.ToString())
                     .AppendLine($"Corps: {this.Corps}")
                     .AppendLine("Missions:");

        foreach (var mission in this.missions)
        {
            stringBuilder.AppendLine($"  {mission}");
        }

        return stringBuilder.ToString().TrimEnd();
    }
}

