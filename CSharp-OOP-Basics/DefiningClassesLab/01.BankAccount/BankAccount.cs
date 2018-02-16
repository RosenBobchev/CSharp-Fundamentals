using System;
using System.Collections.Generic;
using System.Text;


   public class BankAccount
{
    int id;
    decimal balance;

    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    public decimal Balance
    {
        get { return balance; }
        set { balance = value; }
    }
}
