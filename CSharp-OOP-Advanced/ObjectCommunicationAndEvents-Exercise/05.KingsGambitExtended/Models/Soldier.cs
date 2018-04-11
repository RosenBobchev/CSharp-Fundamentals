using System;
using System.Collections.Generic;
using System.Text;

public abstract class Soldier : IPerson
{
    public string Name { get; private set; }

    public int Hitpoints { get; private set; }

    public bool IsAlive { get; private set; }

    protected Soldier(string name, int hitpoints)
    {
        this.Name = name;
        this.Hitpoints = hitpoints;

        this.IsAlive = true;
    }

    public void Die()
    {
        this.IsAlive = false;
    }

    public void TakeDamage()
    {
        this.Hitpoints--;
        if (this.Hitpoints <= 0)
        {
            this.Die();
        }
    }

    public abstract void KindUnderAttack(object sender, EventArgs e);
}