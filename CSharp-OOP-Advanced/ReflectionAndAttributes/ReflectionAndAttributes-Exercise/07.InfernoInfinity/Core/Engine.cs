using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Engine
{
    private WeaponManager manager;
    private GemFactory gemFactory;

    public Engine()
    {
        this.manager = new WeaponManager();
        this.gemFactory = new GemFactory();
    }

    public void Run()
    {
        var command = Console.ReadLine().Split(';');

        while (command[0] != "END")
        {
            switch (command[0])
            {
                case "Create":
                    this.CreateWeapon(command.Skip(1).ToArray());
                    break;
                case "Add":
                    this.AddWeapon(command.Skip(1).ToArray());
                    break;
                case "Remove":
                    this.RemoveWeapon(command.Skip(1).ToArray());
                    break;
                case "Print":

                default:
                    break;
            }

            command = Console.ReadLine().Split(';');
        }

        Console.WriteLine(this.manager.GetAllWeapons());
    }

    private void RemoveWeapon(string[] cmd)
    {
        var weaponName = cmd[0];
        var socketIndex = int.Parse(cmd[1]);
        this.manager.RemoveGemFromWeapon(weaponName, socketIndex);
    }

    private void AddWeapon(string[] cmd)
    {
        var weaponName = cmd[0];
        var socketIndex = int.Parse(cmd[1]);
        var gemType = cmd[2].Split();
        var gem = this.gemFactory.CreateGem(gemType[1], gemType[0]);

        if (gem == null)
        {
            return;
        }

        this.manager.AddGemToWeapon(weaponName, socketIndex, gem);
    }

    private void CreateWeapon(string[] cmd)
    {
        var weaponName = cmd[1];
        var weaponType = cmd[0].Split();
        var weaponKind = weaponType[1];
        var weaponRarity = weaponType[0];

        this.manager.CreateWeapon(weaponKind, weaponName, weaponRarity);
    }
}