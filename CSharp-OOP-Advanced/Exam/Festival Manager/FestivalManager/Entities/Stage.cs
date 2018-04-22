using FestivalManager.Entities.Contracts;
using System.Collections.Generic;
using System.Linq;

public class Stage : IStage
{
    // да си вкарват през полетата бе
    private readonly List<ISet> sets;
    private readonly List<ISong> songs;
    private readonly List<IPerformer> performers;

    public Stage()
    {
        this.sets = new List<ISet>();
        this.songs = new List<ISong>();
        this.performers = new List<IPerformer>();
    }

    public IReadOnlyCollection<ISet> Sets => sets;

    public IReadOnlyCollection<ISong> Songs => songs;

    public IReadOnlyCollection<IPerformer> Performers => performers;

    public void AddPerformer(IPerformer performer)
    {
        this.performers.Add(performer);
    }

    public void AddSet(ISet set)
    {
        this.sets.Add(set);
    }

    public void AddSong(ISong song)
    {
        this.songs.Add(song);
    }

    public IPerformer GetPerformer(string name)
    {
        return this.performers.First(p => p.Name == name);
    }

    public ISet GetSet(string name)
    {
        return this.sets.First(s => s.Name == name);
    }

    public ISong GetSong(string name)
    {
        return this.songs.First(s => s.Name == name);
    }

    public bool HasPerformer(string name)
    {
        return this.performers.Any(p => p.Name == name);
    }

    public bool HasSet(string name)
    {
        return this.sets.Any(s => s.Name == name);
    }

    public bool HasSong(string name)
    {
        return this.songs.Any(s => s.Name == name);
    }
}