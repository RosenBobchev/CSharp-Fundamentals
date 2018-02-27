using System;
using System.Collections.Generic;
using System.Text;

public class Animals : ISoundProducable
{
    private string name;
    private int age;
    private string gender;

    public Animals(string name, int age, string gender)
    {
        this.Name = name;
        this.Age = age;
        this.Gender = gender;
    }

    public string Name
    {
        get { return name; }
        set
        {
            NotEmptyValidation(value);
            name = value;
        }
    }

    public int Age
    {
        get { return age; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Invalid input!");
            }
            age = value;
        }
    }

    public string Gender
    {
        get { return gender; }
        set
        {
            NotEmptyValidation(value);
            if (value != "Male" && value != "Female")
            {
                throw new ArgumentException("Invalid input!");
            }
            gender = value;
        }
    }

    private static void NotEmptyValidation(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Invalid input!");
        }
    }

    public virtual string ProduceSound()
    {
        return "Noise";
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{this.GetType().Name}");
        sb.AppendLine($"{this.Name} {this.Age} {this.Gender}");
        sb.AppendLine($"{this.ProduceSound()}");

        string result = sb.ToString().TrimEnd();
        return result;
    }
}

