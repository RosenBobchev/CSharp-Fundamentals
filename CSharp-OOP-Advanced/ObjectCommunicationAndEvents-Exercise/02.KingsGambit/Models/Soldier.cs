using System;
using System.Collections.Generic;
using System.Text;

public abstract class Soldier : IPerson
{
    public string Name { get; private set; }

    protected Soldier(string name)
    {
        this.Name = name;
    }

    public abstract void KindUnderAttack(object sender, EventArgs e);
}