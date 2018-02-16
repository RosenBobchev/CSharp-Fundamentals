using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var accounts = new Dictionary<int, BankAccount>();

        string command = string.Empty;
        while ((command = Console.ReadLine()) != "End")
        {
            var tokens = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            int accountId = int.Parse(tokens[1]);
            switch (tokens[0])
            {
                case "Create":
                    if (accounts.ContainsKey(accountId))
                    {
                        Console.WriteLine("Account already exists");
                    }
                    else
                    {
                        var account = new BankAccount();
                        account.Id = accountId;
                        accounts.Add(accountId, account);
                    }
                    break;
                case "Deposit":
                    if (ValidateAccount(accountId, accounts))
                    {
                        accounts[accountId].Deposit(int.Parse(tokens[2]));
                    }
                    break;
                case "Withdraw":
                    if (ValidateAccount(accountId, accounts))
                    {
                        accounts[accountId].Withdraw(int.Parse(tokens[2]));
                    }
                    break;
                case "Print":
                    if (ValidateAccount(accountId, accounts))
                    {
                        Console.WriteLine(accounts[accountId]);
                    }
                    break;
            }
        }
    }

    private static bool ValidateAccount(int accountId, Dictionary<int, BankAccount> accounts)
    {
        if (accounts.ContainsKey(accountId))
        {
            return true;
        }
        else
        {
            Console.WriteLine("Account does not exist");
            return false;
        }
    }
}

