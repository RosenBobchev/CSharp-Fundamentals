namespace FestivalManager.Entities.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class InstrumentFactory : IInstrumentFactory
    {
        public IInstrument CreateInstrument(string type)
        {
            Type @class = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(i => i.Name == type);
            var ctors = @class.GetConstructors(BindingFlags.Public | BindingFlags.Instance);
            IInstrument instrument = (IInstrument)ctors[0].Invoke(new object[] { });

            return instrument;
        }
    }
}