using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Entities.Characters;
using DungeonsAndCodeWizards.Entities.Bags;

namespace DungeonsAndCodeWizards.Entities.Items
{
    public class HealthPotion : Item
    {
        public HealthPotion()
            : base(5)
        {
        }

        public override string Name => "HealthPotion";

        public override void AffectCharacter(Character character)
        {
            if (character.IsAlive)
            {
                character.Health += 20;
            }
            else
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }
    }
}
