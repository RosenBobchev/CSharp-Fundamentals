using System;
using System.Collections.Generic;
using System.Text;

public class InvalidSongException : Exception
{
    public InvalidSongException() : base("Invalid song.")
    {
    }

    public InvalidSongException(string message) : base(message)
    {

    }
}

