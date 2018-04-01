using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class WeaponManager
{
    private IList<IWeapon> weapons;
    private WeaponFactory weaponFactory;

    public WeaponManager()
    {
        this.weapons = new List<IWeapon>();
        this.weaponFactory = new WeaponFactory();
    }

    public void CreateWeapon(string weaponKind, string weaponName, string weaponRarity)
    {
        var weapon = this.weaponFactory.CreateWeapon(weaponKind, weaponName, weaponRarity);

        if (weapon != null)
        {
            this.weapons.Add(weapon);
        }
    }

    public string GetAllWeapons()
    {
        StringBuilder sb = new StringBuilder();

        foreach (var weapon in weapons)
        {
            sb.AppendLine(weapon.ToString());
        }

        return sb.ToString().Trim();
    }

    internal void AddGemToWeapon(string weaponName, int socketIndex, IGem gem)
              => this.GetWeapon(weaponName)?.AddGem(gem, socketIndex);

    internal void RemoveGemFromWeapon(string weaponName, int socketIndex)
        => this.GetWeapon(weaponName)?.RemoveGem(socketIndex);

    private IWeapon GetWeapon(string weaponName)
    => this.weapons.FirstOrDefault(w => w.Name == weaponName);
}