using System;

public class Program
{
    static void Main(string[] args)
    {
        int numberOfSongs = int.Parse(Console.ReadLine());
        RadioDatabase database = new RadioDatabase();

        for (int i = 0; i < numberOfSongs; i++)
        {
            Song song = null;
            try
            {
                song = GetSong(database);
            }
            catch (InvalidSongException ex)
            {
                Console.WriteLine(ex.Message);
                continue;
            }

        }

        Console.WriteLine(database);
    }

    private static Song GetSong(RadioDatabase database)
    {
        Song song;
        var tokens = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
        if (tokens.Length != 3)
        {
            throw new InvalidSongException();
        }
        string artist = tokens[0];
        string songName = tokens[1];
        string[] length = tokens[2].Split(':', StringSplitOptions.RemoveEmptyEntries);

        int minutes = 0;
        int seconds = 0;
        if (length.Length != 2)
        {
            throw new InvalidSongLengthException();
        }
        try
        {
            minutes = int.Parse(length[0]);
            seconds = int.Parse(length[1]);
        }
        catch (Exception)
        {
            throw new InvalidSongLengthException();
        }

        song = new Song(artist, songName, minutes, seconds);
        database.AddSong(song);
        Console.WriteLine("Song added.");
        return song;
    }
}

