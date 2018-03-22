using DungeonsAndCodeWizards.Entities.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Entities.Bags
{
    public abstract class Bag
    {
        private int capacity;

        public Bag(int capacity)
        {
            this.Capacity = capacity;
        }

        private List<Item> items = new List<Item>();

        public IReadOnlyCollection<Item> Items => items;

        public int Capacity
        {
            get { return capacity; }
            protected set { capacity = value; }
        }

        public int Load => this.items.Select(i => i.Weight).Sum();

        public void AddItem(Item item)
        {
            if ((item.Weight + this.Load) > this.Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }
            else
            {
                items.Add(item);
            }
        }

        public Item GetItem(string name)
        {
            if (!this.items.Any())
            {
                throw new InvalidOperationException("Bag is empty!");
            }
            else if (!items.Any(i => i.Name == name))
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }

            var item = this.items.First(i => i.GetType().Name == name);
            this.items.Remove(item);

            return item;
        }
    }
}
