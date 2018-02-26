using System;
using System.Collections.Generic;
using System.Text;

public class Student:Human
{
    private const int MIN_LENGTH = 5;
    private const int MAX_LENGTH = 10;
    private string facultyNumber;

    public Student(string firstName, string lastName, string facultyNumber)
        : base(firstName, lastName)
    {
        this.FacultyNumber = facultyNumber;
    }

    public string FacultyNumber
    {
        get { return facultyNumber; }
        set
        {
            if (value.Length < MIN_LENGTH || value.Length > MAX_LENGTH)
            {
                throw new ArgumentException("Invalid faculty number!");
            }

            foreach (var c in value)
            {
                if (!char.IsLetterOrDigit(c))
                {
                    throw new ArgumentException("Invalid faculty number!");
                }
            }
            facultyNumber = value;
        }
    }

    public bool ValidateFacilityNumber(string value)
    {
        if (value.Length < MIN_LENGTH || value.Length > MAX_LENGTH)
        {
            return false;
        }

        foreach (var c in value)
        {
            if (!char.IsLetterOrDigit(c))
            {
                return false;
            }
        }

        return true;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"First Name: {this.FirstName}");
        sb.AppendLine($"Last Name: {this.LastName}");
        sb.AppendLine($"Faculty number: {this.FacultyNumber}");

        string result = sb.ToString().TrimEnd();
        return result;
    }
}

