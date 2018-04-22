using System;

public class Medium : Set
{
    public Medium(string name)
        : base(name)
    {
    }

    public override TimeSpan MaxDuration => new TimeSpan(0,40,0);
}