using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Entities.Items;
using DungeonsAndCodeWizards.Entities.Bags;

namespace DungeonsAndCodeWizards.Factories
{
    public class ItemFactory
    {
        public Item CreateItem(string itemName)
        {
            switch (itemName)
            {
                case "ArmorRepairKit":
                    return new ArmorRepairKit();
                case "HealthPotion":
                    return new HealthPotion();
                case "PoisonPotion":
                    return new PoisonPotion();
                default:
                    throw new ArgumentException($"Invalid item \"{itemName}\"!");
            }
        }
    }
}
