using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Entities.Characters;
using DungeonsAndCodeWizards.Entities.Bags;

namespace DungeonsAndCodeWizards.Entities.Items
{
    public class PoisonPotion : Item
    {
        public PoisonPotion()
            : base(5)
        {
        }

        public override string Name => "PoisonPotion";

        public override void AffectCharacter(Character character)
        {
            if (character.IsAlive)
            {
                character.Health = Math.Max(0, character.Health - 20);

                if (character.Health == 0)
                {
                    character.IsAlive = false;
                }
            }
            else
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }
    }
}
