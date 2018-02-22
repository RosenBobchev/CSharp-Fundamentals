using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
    private string name;
    private decimal money;
    public List<Product> Products { get; set; }

    public Person(string name, decimal money)
    {
        this.Name = name;
        this.Money = money;
        this.Products = new List<Product>();
    }

    public string Name
    {
        get { return name; }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }
            name = value;
        }
    }


    public decimal Money
    {
        get { return money; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
            money = value;
        }
    }
}

