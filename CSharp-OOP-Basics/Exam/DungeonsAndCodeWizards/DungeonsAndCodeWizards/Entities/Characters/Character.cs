using System;
using DungeonsAndCodeWizards.Entities.Items;
using DungeonsAndCodeWizards.Entities.Bags;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Entities.Characters
{
    public abstract class Character
    {
        private List<Character> characters;
        private string name;
        private double baseHealth;
        private double health;
        private double baseArmor;
        private double armor;
        private double abilityPoints;
        private Faction faction;
        private Bag bag;

        protected Character(string name, double baseHealth, double baseArmor, double abilityPoints, Bag bag, Faction faction)
        {
            this.Name = name;
            this.BaseHealth = baseHealth;
            this.BaseArmor = baseArmor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.Faction = faction;
            IsAlive = true;
            this.characters = new List<Character>();
        }

        public string Name
        {
            get
            {
                return name;
            }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                name = value;
            }
        }

        public double BaseHealth
        {
            get { return baseHealth; }
            protected set { baseHealth = value; }
        }

        public double Health
        {
            get { return health; }
            set
            {
                if (value > this.BaseHealth)
                {
                    value = this.BaseHealth;
                }
                else if (value <= 0)
                {
                    value = 0;
                    this.IsAlive = false;
                }
                health = value;
            }
        }

        public double BaseArmor
        {
            get { return baseArmor; }
            protected set { baseArmor = value; }
        }

        public double Armor
        {
            get { return armor; }
            set
            {
                if (value > this.BaseArmor)
                {
                    value = this.BaseArmor;
                }
                else if (value <= 0)
                {
                    value = 0;
                }
                armor = value;
            }
        }

        public double AbilityPoints
        {
            get { return abilityPoints; }
            protected set { abilityPoints = value; }
        }

        public Bag Bag
        {
            get { return bag; }
            protected set { bag = value; }
        }

        public bool IsAlive { get; set; }

        public Faction Faction
        {
            get { return faction; }
            protected set { faction = value; }
        }

        public virtual double RestHealthMultiplier => 0.2;

        public void TakeDamage(double hitPoints)
        {
            if (IsAlive)
            {
                if (this.Armor > 0)
                {
                    if (this.Armor - hitPoints < 0)
                    {
                        hitPoints -= this.Armor;
                        this.Armor = 0;
                    }
                    else
                    {
                        this.Armor -= hitPoints;
                    }

                }
                if (this.Armor == 0)
                {
                    if (this.Health > 0)
                    {
                        if (this.Health - hitPoints < 0)
                        {
                            this.Health = 0;
                        }
                        else
                        {
                            this.Health -= hitPoints;
                        }
                    }
                }

                if (this.Health <= 0)
                {
                    IsAlive = false;
                }
            }
            else
            {
                IsCharacterAlive();
            }
        }

        public void Rest()
        {
            if (IsAlive)
            {
                var healToAdd = this.Health + (this.BaseHealth * this.RestHealthMultiplier);
                if (healToAdd < this.BaseHealth)
                {
                    this.Health += this.BaseHealth * this.RestHealthMultiplier;
                }
                else
                {
                    this.Health = this.BaseHealth;
                }
            }
            else
            {
                IsCharacterAlive();
            }
        }

        public void UseItem(Item item)
        {
            if (IsAlive)
            {
                var currentCharacter = this;
                item.AffectCharacter(currentCharacter);
            }
            else
            {
                IsCharacterAlive();
            }
        }

        public void UseItemOn(Item item, Character character)
        {
            var currentCharacter = this;
            if (currentCharacter.IsAlive && character.IsAlive)
            {
                item.AffectCharacter(character);
            }
            else
            {
                IsCharacterAlive();
            }
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            var currentCharacter = this;
            if (currentCharacter.IsAlive && character.IsAlive)
            {
                character.bag.AddItem(item);
            }
            else
            {
                IsCharacterAlive();
            }
        }

        public void ReceiveItem(Item item)
        {
            if (IsAlive)
            {
                bag.AddItem(item);
            }
            else
            {
                IsCharacterAlive();
            }
        }

        public void IsCharacterAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }
    }
}
