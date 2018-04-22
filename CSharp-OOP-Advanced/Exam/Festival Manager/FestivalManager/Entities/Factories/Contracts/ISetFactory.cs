namespace FestivalManager.Entities.Factories
{
    public interface ISetFactory
    {
        ISet CreateSet(string name, string type);
    }
}