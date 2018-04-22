using FestivalManager.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Set : ISet
{
    private readonly List<IPerformer> performers;
    private readonly List<ISong> songs;

    protected Set(string name)
    {
        this.Name = name;
        this.performers = new List<IPerformer>();
        this.songs = new List<ISong>();
    }

    public string Name { get; set; }

    public abstract TimeSpan MaxDuration { get; }

    public TimeSpan ActualDuration => new TimeSpan(this.Songs.Sum(s => s.Duration.Ticks));

    public IReadOnlyCollection<IPerformer> Performers => performers;

    public IReadOnlyCollection<ISong> Songs => songs;

    public void AddPerformer(IPerformer performer)
    {
        performers.Add(performer);
    }

    public void AddSong(ISong song)
    {
        if (song.Duration + this.ActualDuration > this.MaxDuration)
        {
            throw new InvalidOperationException("Song is over the set limit!");
        }

        this.songs.Add(song);
    }

    public bool CanPerform()
    {
        if (performers.Any() && songs.Any() && this.Performers.All(p => p.Instruments.Any(i => !i.IsBroken)))
        {
            return true;
        }

        return false;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine(string.Join(", ", this.Performers));

        foreach (var song in this.Songs)
        {
            sb.AppendLine($"-- {song}");
        }

        var result = sb.ToString();
        return result;
    }
}