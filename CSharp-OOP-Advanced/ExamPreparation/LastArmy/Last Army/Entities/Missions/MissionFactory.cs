using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

public class MissionFactory : IMissionFactory
{
    public IMission CreateMission(string missionName, double neededPoints)
    {
        Type missionType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(m => m.Name == missionName);

        return (IMission)Activator.CreateInstance(missionType, neededPoints);
    }
}