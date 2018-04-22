using System;

public interface ISongFactory
{
    ISong CreateSong(string name, TimeSpan duration);
}