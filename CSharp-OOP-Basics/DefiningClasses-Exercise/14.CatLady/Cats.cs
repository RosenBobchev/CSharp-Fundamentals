using System;
using System.Collections.Generic;
using System.Text;
    
public class Cats
{
    public string Breed { get; set; }
    public string Name { get; set; }
    public double? EarSize { get; set; }
    public double? FurLength { get; set; }
    public double? Decibels { get; set; }

    public Cats(string breed, string name)
    {
        this.Breed = breed;
        this.Name = name;
        this.EarSize = null;
        this.FurLength = null;
        this.Decibels = null;
    }
    
    public override string ToString()
    {
        var result = new StringBuilder();
        result.Append($"{this.Breed} {this.Name} ");

        if (!this.EarSize.Equals(null))
        {
            result.Append((int)this.EarSize);
        }
        else if (!this.FurLength.Equals(null))
        {
            result.Append($"{this.FurLength:F2}");
        }
        else
        {
            result.Append((int)this.Decibels);
        }

        return result.ToString();
    }
}

