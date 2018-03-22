using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Entities.Bags;

namespace DungeonsAndCodeWizards.Entities.Characters
{
    public class Cleric : Character, IHealable
    {
        public Cleric(string name, Faction faction)
            : base(name, 50, 25, 40, new Backpack(), faction)
        {
            this.Health = this.BaseHealth;
            this.Armor = this.BaseArmor;
        }
        
        public override double RestHealthMultiplier => 0.5;

        public void Heal(Character character)
        {
            var currentCharacter = this;

            if (!currentCharacter.IsAlive || !character.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
            if (this.Faction != character.Faction)
            {
                throw new InvalidOperationException("Cannot heal enemy character!");
            }
            character.Health = Math.Min(character.BaseHealth, character.Health + this.AbilityPoints);
        }
    }
}
