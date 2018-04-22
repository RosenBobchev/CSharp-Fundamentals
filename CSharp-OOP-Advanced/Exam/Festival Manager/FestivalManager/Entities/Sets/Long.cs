using System;

public class Long : Set
{
    public Long(string name)
        : base(name)
    {
    }

    public override TimeSpan MaxDuration => new TimeSpan(0,60,0);
}