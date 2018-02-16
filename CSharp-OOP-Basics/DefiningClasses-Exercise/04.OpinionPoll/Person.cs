using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
    private int age;

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public Person(string name, int age)
    {
        this.age = age;
        this.name = name;
    }

    public Person(int age)
    {
        this.age = age;
        this.name = "No name";
    }

    public Person()
    {
        this.age = 1;
        this.name = "No name";
    }
}

