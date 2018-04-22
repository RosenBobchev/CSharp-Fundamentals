using FestivalManager.Entities.Contracts;

namespace FestivalManager.Entities.Factories
{
    public interface IPerformerFactory
    {
        IPerformer CreatePerformer(string name, int age);
    }
}