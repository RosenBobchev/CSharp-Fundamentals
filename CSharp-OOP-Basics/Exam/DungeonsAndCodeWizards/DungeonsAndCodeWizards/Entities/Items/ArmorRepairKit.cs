using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Entities.Characters;
using DungeonsAndCodeWizards.Entities.Bags;

namespace DungeonsAndCodeWizards.Entities.Items
{
    public class ArmorRepairKit : Item
    {
        public ArmorRepairKit()
            : base(10)
        {
        }

        public override string Name => "ArmorRepairKit";

        public override void AffectCharacter(Character character)
        {
            if (character.IsAlive)
            {
                character.Armor = character.BaseArmor;
            }
            else
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }
    }
}
