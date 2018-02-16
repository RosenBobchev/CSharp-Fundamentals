using System;
using System.Collections.Generic;
using System.Text;

public class Company
{
    private string companyName;
    private string department;
    private decimal salary;

    public Company()
    {

    }

    public Company(string companyName, string department, decimal salary)
    {
        this.CompanyName = companyName;
        this.Department = department;
        this.Salary = salary;
    }

    public string CompanyName
    {
        get { return companyName; }
        set { companyName = value; }
    }
    
    public string Department
    {
        get { return department; }
        set { department = value; }
    }
    
    public decimal Salary
    {
        get { return salary; }
        set { salary = value; }
    }

}

