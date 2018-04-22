using System;

public class Short : Set
{
    public Short(string name)
        : base(name)
    {
    }

    public override TimeSpan MaxDuration => new TimeSpan(0,15,0);
}