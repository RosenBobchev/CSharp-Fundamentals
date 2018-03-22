using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Entities.Characters;
using DungeonsAndCodeWizards.Entities.Bags;

namespace DungeonsAndCodeWizards.Entities.Items
{
    public abstract class Item
    {
        private int weight;

        protected Item(int weight)
        {
            this.Weight = weight;
        }

        public virtual string Name { get; set; }

        public int Weight
        {
            get { return weight; }
            protected set { weight = value; }
        }
        
        public abstract void AffectCharacter(Character character);
    }
}
