using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Entities.Bags;

namespace DungeonsAndCodeWizards.Entities.Characters
{
    public class Warrior : Character, IAttackable
    {
        public Warrior(string name, Faction faction)
            : base(name, 100, 50, 40, new Satchel(), faction)
        {
            this.Health = this.BaseHealth;
            this.Armor = this.BaseArmor;
        }

        public void Attack(Character character)
        {
            if (!this.IsAlive || !character.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
            if (this == character)
            {
                throw new InvalidOperationException("Cannot attack self!");
            }
            if (this.Faction == character.Faction)
            {
                throw new ArgumentException($"Friendly fire! Both characters are from {this.Faction} faction!");
            }
            
            character.TakeDamage(this.AbilityPoints);
        }
    }
}
