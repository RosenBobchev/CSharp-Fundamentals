using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Topping
{
    private const int MIN_WEIGHT = 1;
    private const int MAX_WEIGHT = 50;
    private const double DEFAULT_MULTIPLYER = 2;

    private Dictionary<string, double> validToppings = new Dictionary<string, double>
    {
        ["meat"] = 1.2,
        ["veggies"] = 0.8,
        ["cheese"] = 1.1,
        ["sauce"] = 0.9
    };

    private string type;
    private double weight;

    public Topping(string type, double weight)
    {
        this.Type = type;
        ValidateWeight(type, weight);
        this.Weight = weight;
    }

    private double TypeMultiplyer => validToppings[type];

    public double Calories => DEFAULT_MULTIPLYER * this.Weight * TypeMultiplyer;

    public string Type
    {
        get { return type; }
        set
        {
            if (!this.validToppings.ContainsKey(value.ToLower()))
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }
            type = value.ToLower();
        }
    }
    
    public double Weight
    {
        get { return weight; }
        set
        {
            weight = value;
        }
    }

    private void ValidateWeight(string type, double weight)
    {
        if (weight < MIN_WEIGHT || weight > MAX_WEIGHT)
        {
            throw new ArgumentException($"{type} weight should be in the range [{MIN_WEIGHT}..{MAX_WEIGHT}].");
        }
    }
}

