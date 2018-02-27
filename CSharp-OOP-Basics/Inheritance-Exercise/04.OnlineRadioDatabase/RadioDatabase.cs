using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RadioDatabase
{
    private long numberOfSongsAdded;
    private List<Song> songs;
    private DateTime totalLength;

    public RadioDatabase()
    {
        this.numberOfSongsAdded = 0;
        this.songs = new List<Song>();
        this.totalLength = new DateTime();
    }

    public void AddSong(Song song)
    {
        this.songs.Add(song);
        this.numberOfSongsAdded++;
    }

    private void SetTotalLength()
    {
        double totalMinutes = songs.Sum(s => s.Minutes);
        double totalSeconds = songs.Sum(s => s.Seconds);
        this.totalLength = this.totalLength.AddMinutes(totalMinutes);
        this.totalLength = this.totalLength.AddSeconds(totalSeconds);
    }

    public override string ToString()
    {
        SetTotalLength();

        return $"Songs added: {this.numberOfSongsAdded}{Environment.NewLine}" +
            $"Playlist length: {this.totalLength.Hour}h {this.totalLength.Minute}m {this.totalLength.Second}s";
    }
}

