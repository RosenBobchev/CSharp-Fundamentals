using FestivalManager.Entities.Contracts;
using FestivalManager.Entities.Factories;
using System;
using System.Linq;
using System.Reflection;

public class PerformerFactory : IPerformerFactory
{
    public IPerformer CreatePerformer(string name, int age)
    {
        Type clazz = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name == "Performer");
        var ctors = clazz.GetConstructors(BindingFlags.Public | BindingFlags.Instance);
        IPerformer performer = (IPerformer)ctors[0].Invoke(new object[] { name, age });

        return performer;
    }

    IPerformer IPerformerFactory.CreatePerformer(string name, int age)
    {
        throw new NotImplementedException();
    }
}