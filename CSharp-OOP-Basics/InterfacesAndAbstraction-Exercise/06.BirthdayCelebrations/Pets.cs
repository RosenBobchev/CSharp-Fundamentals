using System;
using System.Collections.Generic;
using System.Text;

public class Pets : IBirthable
{
    public Pets(string name, string birthdate)
    {
        this.Name = name;
        this.BirthDate = birthdate;
    }

    public string Name { get; private set; }

    public string BirthDate { get; private set; }
}

