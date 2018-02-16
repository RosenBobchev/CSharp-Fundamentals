using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
    public Person(string name)
    {
        this.Name = name;
        this.Company = new Company();
        this.Car = new Car();
        this.Pokemons = new List<Pokemon>();
        this.Parents = new List<Parents>();
        this.Children = new List<Children>();
    }

    public string Name { get; set; }
    public Company Company { get; set; }
    public Car Car { get; set; }
    public List<Pokemon> Pokemons { get; set; }
    public List<Parents> Parents { get; set; }
    public List<Children> Children { get; set; }

    public override string ToString()
    {
        var result = new StringBuilder();
        result.AppendLine(this.Name);
        result.AppendLine($"Company:");
        if (this.Company.CompanyName != null)
        {
            result.AppendLine($"{this.Company.CompanyName} {this.Company.Department} {this.Company.Salary:F2}");
        }

        result.AppendLine("Car:");
        if (this.Car.Model != null)
        {
            result.AppendLine($"{this.Car.Model} {this.Car.Speed}");
        }

        result.AppendLine("Pokemon:");
        foreach (var pokemon in Pokemons)
        {
            result.AppendLine($"{pokemon.Name} {pokemon.Type}");
        }

        result.AppendLine("Parents:");
        foreach (var parent in Parents)
        {
            result.AppendLine($"{parent.ParentName} {parent.ParentBirthday}");
        }

        result.AppendLine("Children:");
        foreach (var child in Children)
        {
            result.AppendLine($"{child.ChildName} {child.ChildBirthday}");
        }

        return result.ToString();
    }
}

