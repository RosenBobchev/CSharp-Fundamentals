using FestivalManager.Entities.Factories;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

public class FestivalController : IFestivalController
{
    private const string TimeFormat = "mm\\:ss";
    private const string TimeFormatLong = "{0:2D}:{1:2D}";
    private const string TimeFormatThreeDimensional = "{0:3D}:{1:3D}";

    private readonly IStage stage;
    private SetFactory setFactory;
    private InstrumentFactory instrumentFactory;
    private PerformerFactory performerFactory;
    private SongFactory songFactory;

    public FestivalController(IStage stage)
    {
        this.stage = stage;
        this.setFactory = new SetFactory();
        this.instrumentFactory = new InstrumentFactory();
        this.performerFactory = new PerformerFactory();
        this.songFactory = new SongFactory();
    }

    private string FormatTime(TimeSpan timeSpan)
    {
        int mins = timeSpan.Days * 1440 + timeSpan.Hours * 60 + timeSpan.Minutes;
        int secs = timeSpan.Seconds;

        return $"{mins:d2}:{secs:d2}";
    }

    public string ProduceReport()
    {
        var result = string.Empty;

        var totalFestivalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));
        
        result += ($"Festival length: {FormatTime(totalFestivalLength)}") + "\n";

        foreach (var set in this.stage.Sets)
        {
            result += $"--{set.Name} ({FormatTime(set.ActualDuration)}):" + "\n";

            var performersOrderedDescendingByAge = set.Performers.OrderByDescending(p => p.Age);
            foreach (var performer in performersOrderedDescendingByAge)
            {
                var instruments = string.Join(", ", performer.Instruments
                    .OrderByDescending(i => i.Wear));

                result += ($"---{performer.Name} ({instruments})") + "\n";
            }

            if (!set.Songs.Any())
                result += ("--No songs played") + "\n";
            else
            {
                result += ("--Songs played:") + "\n";
                foreach (var song in set.Songs)
                {
                    result += ($"----{song.Name} ({song.Duration:mm\\:ss})") + "\n";
                }
            }
        }

        return result.ToString();
    }

    public string RegisterSet(string[] args)
    {
        string name = args[0];
        string type = args[1];

        var set = this.setFactory.CreateSet(name, type);
        stage.AddSet(set);

        return $"Registered {type} set";
    }

    public string SignUpPerformer(string[] args)
    {
        var name = args[0];
        var age = int.Parse(args[1]);

        var instrumentsInput = args.Skip(2).ToArray();

        var instruments = instrumentsInput
            .Select(i => this.instrumentFactory.CreateInstrument(i))
            .ToArray();

        var performer = this.performerFactory.CreatePerformer(name, age);

        foreach (var instrument in instruments)
        {
            performer.AddInstrument(instrument);
        }

        this.stage.AddPerformer(performer);

        return $"Registered performer {performer.Name}";
    }

    public string RegisterSong(string[] args)
    {
        string name = args[0];
        string min = args[1].Split(':')[0];
        string sec = args[1].Split(':')[1];
        TimeSpan duration = new TimeSpan(0, int.Parse(min), int.Parse(sec));

        var song = this.songFactory.CreateSong(name, duration);

        this.stage.AddSong(song);

        return $"Registered song {song.Name} ({song.Duration:mm\\:ss})";
    }

    public string AddSongToSet(string[] args)
    {
        var songName = args[0];
        var setName = args[1];

        if (!this.stage.HasSet(setName))
        {
            throw new InvalidOperationException("Invalid set provided");
        }

        if (!this.stage.HasSong(songName))
        {
            throw new InvalidOperationException("Invalid song provided");
        }

        var set = this.stage.GetSet(setName);
        var song = this.stage.GetSong(songName);

        set.AddSong(song);

        return $"Added {song.Name} ({song.Duration:mm\\:ss}) to {set.Name}";
    }

    public string AddPerformerToSet(string[] args)
    {
        var performerName = args[0];
        var setName = args[1];

        if (!this.stage.HasPerformer(performerName))
        {
            throw new InvalidOperationException("Invalid performer provided");
        }

        if (!this.stage.HasSet(setName))
        {
            throw new InvalidOperationException("Invalid set provided");
        }

        var performer = this.stage.GetPerformer(performerName);
        var set = this.stage.GetSet(setName);

        set.AddPerformer(performer);

        return $"Added {performer.Name} to {set.Name}";
    }

    public string RepairInstruments(string[] args)
    {
        var instrumentsToRepair = this.stage.Performers
            .SelectMany(p => p.Instruments)
            .Where(i => i.Wear < 100)
            .ToArray();

        foreach (var instrument in instrumentsToRepair)
        {
            instrument.Repair();
        }

        return $"Repaired {instrumentsToRepair.Length} instruments";
    }
}