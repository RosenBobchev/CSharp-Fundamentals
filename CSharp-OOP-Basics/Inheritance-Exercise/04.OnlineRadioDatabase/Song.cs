using System;
using System.Collections.Generic;
using System.Text;

public class Song
{
    private const int MIN_ARTIST_LENGTH = 3;
    private const int MAX_ARTIST_LENGTH = 20;
    private const int MIN_SONG_LENGTH = 3;
    private const int MAX_SONG_LENGTH = 30;
    private const int MAX_MINUTES = 14;
    private const int MAX_SECONDS = 59;
    private string artist;
    private string songName;
    private int minutes;
    private int seconds;

    public Song(string artist, string songName, int minutes, int seconds)
    {
        this.Artist = artist;
        this.SongName = songName;
        this.Minutes = minutes;
        this.Seconds = seconds;
    }
    
    public string Artist
    {
        get { return artist; }
        set
        {
            if (value == null || value.Length < MIN_ARTIST_LENGTH || value.Length > MAX_ARTIST_LENGTH)
            {
                throw new InvalidArtistNameException();
            }
            artist = value;
        }
    }
    
    public string SongName
    {
        get { return songName; }
        set
        {
            if (value == null || value.Length < MIN_SONG_LENGTH || value.Length > MAX_SONG_LENGTH)
            {
                throw new InvalidSongNameException();
            }
            songName = value;
        }
    }

    public int Minutes
    {
        get { return minutes; }
        set
        {
            if (value < 0 || value > MAX_MINUTES)
            {
                throw new InvalidSongMinutesException();
            }
            minutes = value;
        }
    }

    public int Seconds
    {
        get { return seconds; }
        set
        {
            if (value < 0 || value > MAX_SECONDS)
            {
                throw new InvalidSongSecondsException();
            }
            seconds = value;
        }
    }
}

