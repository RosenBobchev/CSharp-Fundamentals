using System;
using System.Collections.Generic;
using System.Text;

public class Footman : Soldier
{
    public Footman(string name)
        : base(name, 2)
    {
    }

    public override void KindUnderAttack(object sender, EventArgs e)
    {
        if (IsAlive)
        {
            Console.WriteLine($"Footman {this.Name} is panicking!");
        }
    }
}