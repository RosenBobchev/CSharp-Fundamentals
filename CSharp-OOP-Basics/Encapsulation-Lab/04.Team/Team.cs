using System;
using System.Collections.Generic;
using System.Text;

public class Team
{

    private string name;
    private List<Person> firstTeam;
    private List<Person> reserveTeam;

    public Team(string name)
    {
        this.firstTeam = new List<Person>();
        this.reserveTeam = new List<Person>();
        this.Name = name;
    }

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public List<Person> FirstTeam
    {
        get { return this.firstTeam; }
    }

    public List<Person> ReserveTeam
    {
        get { return this.reserveTeam; }
    }

    public void AddPlayer(Person person)
    {
        if (person.Age < 40)
        {
            firstTeam.Add(person);
        }
        else
        {
            reserveTeam.Add(person);
        }
    }
}

