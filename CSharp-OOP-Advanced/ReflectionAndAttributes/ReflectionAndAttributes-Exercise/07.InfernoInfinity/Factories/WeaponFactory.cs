using System;
using System.Collections.Generic;
using System.Text;

public class WeaponFactory
{
    public IWeapon CreateWeapon(string weaponKind, string weaponName, string weaponRarity)
    {
        WeaponRarity rarity;
        var isRarityValid = Enum.TryParse(weaponRarity, out rarity);

        if (!isRarityValid)
        {
            return null;
        }

        switch (weaponKind)
        {
            case "Axe":
                return new Axe(weaponName, rarity);
            case "Sword":
                return new Sword(weaponName, rarity);
            case "Knife":
                return new Knife(weaponName, rarity);
            default:
                return null;
        }
    }
}