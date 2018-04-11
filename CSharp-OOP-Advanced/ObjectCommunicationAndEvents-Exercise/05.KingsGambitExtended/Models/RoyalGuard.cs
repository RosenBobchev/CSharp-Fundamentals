using System;
using System.Collections.Generic;
using System.Text;

public class RoyalGuard : Soldier
{
    public RoyalGuard(string name)
        : base(name, 3)
    {
    }

    public override void KindUnderAttack(object sender, EventArgs e)
    {
        if (IsAlive)
        {
            Console.WriteLine($"Royal Guard {this.Name} is defending!");
        }
    }
}