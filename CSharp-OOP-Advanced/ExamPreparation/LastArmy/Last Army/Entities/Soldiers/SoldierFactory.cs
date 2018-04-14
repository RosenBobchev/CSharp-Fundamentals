using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

public class SoldierFactory : ISoldierFactory
{
    public ISoldier CreateSoldier(string soldierTypeName, string name, int age, double experience, double endurance)
    {
        Type soldierType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(s => s.Name == soldierTypeName);

        return (ISoldier)Activator.CreateInstance(soldierType, name, age, experience, endurance);
    }
}