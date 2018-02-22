using System;
using System.Collections.Generic;
using System.Text;

public class Stats
{
    private const int MIN_LEVEL = 0;
    private const int MAX_LEVEL = 100;
    private const string LEVEL_ERROR = "{0} should be between {1} and {2}.";

    private string name;
    private int level;

    public Stats(string name, int level)
    {
        this.Name = name;
        this.Level = level;
    }

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public int Level
    {
        get { return this.level; }
        set
        {
            if (value < MIN_LEVEL || value > MAX_LEVEL)
            {
                throw new ArgumentException(string.Format(LEVEL_ERROR, this.Name, MIN_LEVEL, MAX_LEVEL));
            }
            this.level = value;
        }
    }
}

