using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Monument
{
    private string name;
    private int affinity;
    private string type;

    protected Monument(string name, int affinity, string type)
    {
        this.Name = name;
        this.Affinity = affinity;
        this.Type = type;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Affinity
    {
        get { return affinity; }
        set { affinity = value; }
    }

    public string Type
    {
        get { return type; }
        set { type = value; }
    }
    
    public abstract double GetAffinity();

    public override string ToString()
    {
        return $"Monument: {this.name}";
    }
}

