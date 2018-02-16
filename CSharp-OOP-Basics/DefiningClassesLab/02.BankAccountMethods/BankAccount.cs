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

    public void Deposit(decimal amount)
    {
        Balance += amount;
    }
    
    public void Withdraw(decimal amount)
    {
        Balance -= amount;
    }

    public override string ToString()
    {
        return $"Account {Id}, balance {Balance}";
    }
}

