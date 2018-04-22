namespace FestivalManager.Entities.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class SetFactory : ISetFactory
    {
        public ISet CreateSet(string name, string type)
        {
            Type clazz = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name == type);
            var ctors = clazz.GetConstructors(BindingFlags.Public | BindingFlags.Instance);
            ISet set = (ISet)ctors[0].Invoke(new object[] { name });

            return set;
        }
    }
}