using System;
using System.Collections.Generic;
using System.Text;

public class King : IPerson
{
    public event EventHandler UnderAttack;

    public string Name { get; private set; }

    public King(string name)
    {
        this.Name = name;
    }

    public void OnUnderAttack()
    {
        Console.WriteLine($"King {this.Name} is under attack!");
        this.UnderAttack?.Invoke(this, new EventArgs());
    }
}