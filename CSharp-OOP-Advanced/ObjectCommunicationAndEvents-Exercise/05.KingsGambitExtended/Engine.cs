using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Engine
{
    private King king;
    private List<Soldier> soldiers;

    public Engine()
    {
        this.soldiers = new List<Soldier>();
    }

    public void Run()
    {
        this.BuildKingdom();
        this.ExecuteCommands();
    }

    private void BuildKingdom()
    {
        var kingName = Console.ReadLine();
        this.king = new King(kingName);

        var royalGuardNames = Console.ReadLine().Split();
        foreach (var name in royalGuardNames)
        {
            var royalGuard = new RoyalGuard(name);
            this.soldiers.Add(royalGuard);
            this.king.UnderAttack += royalGuard.KindUnderAttack;
        }

        var footmanNames = Console.ReadLine().Split();
        foreach (var name in footmanNames)
        {
            var footman = new Footman(name);
            this.soldiers.Add(footman);
            this.king.UnderAttack += footman.KindUnderAttack;
        }
    }

    private void ExecuteCommands()
    {
        var command = Console.ReadLine().Split();

        while (command[0] != "End")
        {
            switch (command[0])
            {
                case "Attack":
                    this.king.OnUnderAttack();
                    break;
                case "Kill":
                    var soldier = this.soldiers.FirstOrDefault(s => s.Name == command[1]);
                    soldier.TakeDamage();
                    break;
            }

            command = Console.ReadLine().Split();
        }
    }
}