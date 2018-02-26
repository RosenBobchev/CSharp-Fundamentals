using System;
using System.Collections.Generic;
using System.Text;

public class Worker:Human
{
    private const decimal MIN_SALARY = 10;
    private const int MIN_HOURS = 1;
    private const int MAX_HOURS = 10;
    private decimal weekSalary;
    private decimal workingHours;

    public Worker(string firstName, string lastName, decimal weekSalary, decimal workingHours) : base(firstName, lastName)
    {
        this.WeekSalary = weekSalary;
        this.WorkingHours = workingHours;
    }
    
    public decimal WeekSalary
    {
        get { return weekSalary; }
        set
        {
            if (value <= MIN_SALARY)
            {
                throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
            }
            weekSalary = value;
        }
    }

    public decimal WorkingHours
    {
        get { return workingHours; }
        set
        {
            if (value < MIN_HOURS || value > MAX_HOURS)
            {
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
            }
            workingHours = value;
        }
    }

    private decimal CalculateSalary(decimal weekSalary, decimal workingHours)
    {
        decimal SalaryPerHour = weekSalary / (workingHours * 5);
        return SalaryPerHour;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"First Name: {this.FirstName}");
        sb.AppendLine($"Last Name: {this.LastName}");
        sb.AppendLine($"Week Salary: {this.WeekSalary:F2}");
        sb.AppendLine($"Hours per day: {this.WorkingHours:F2}");
        sb.AppendLine($"Salary per hour: {this.CalculateSalary(weekSalary, workingHours):F2}");

        string result = sb.ToString().TrimEnd();
        return result;
    }
}

