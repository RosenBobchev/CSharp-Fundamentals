using System;
using System.Collections.Generic;
using System.Text;

public class Car
{
    public string Model { get; set; }
    public Engine Engine { get; set; }
    public string Weight { get; set; }
    public string Color { get; set; }

    public Car(string Model, Engine Engine)
    {
        this.Model = Model;
        this.Engine = Engine;
        this.Weight = "n/a";
        this.Color = "n/a";
    }

    public override string ToString()
    {
        var result = new StringBuilder();
        result.AppendLine($"{this.Model}:");
        result.AppendLine($"  {this.Engine.Model}:");
        result.AppendLine($"    Power: {this.Engine.Power}");
        result.AppendLine($"    Displacement: {this.Engine.Displacement}");
        result.AppendLine($"    Efficiency: {this.Engine.Efficiency}");
        result.AppendLine($"  Weight: {this.Weight}");
        result.AppendLine($"  Color: {this.Color}");

        return result.ToString().Trim();
    }
}

