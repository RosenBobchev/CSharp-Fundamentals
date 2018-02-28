using System;
using System.Collections.Generic;
using System.Text;

public class Citizen : IIdentable, IBirthable
{
    public Citizen(string name, int age, string id, string birthdate)
    {
        this.Name = name;
        this.Age = age;
        this.Id = id;
        this.BirthDate = birthdate;
    }

    public string Name { get; private set; }

    public int Age { get; private set; }

    public string Id { get; private set; }

    public string BirthDate { get; private set; }
}

