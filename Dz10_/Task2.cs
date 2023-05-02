using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dz10_
{
    public class Backpack
    {
        public string Color { get; set; }
        public string Brand { get; set; }
        public string Fabric { get; set; }
        public double Weight { get; set; }
        public double Volume { get; set; }
        public List<Item> Contents { get; set; }

        public event EventHandler<ItemEventArgs> ItemAdded;

        public Backpack(string color, string brand, string fabric, double weight, double volume)
        {
            Color = color;
            Brand = brand;
            Fabric = fabric;
            Weight = weight;
            Volume = volume;
            Contents = new List<Item>();
        }

        public void AddItem(Item item)
        {
            if (item.Volume > Volume - GetOccupiedVolume())
            {
                throw new Exception("Cannot add item: not enough space in backpack.");
            }
            Contents.Add(item);
            ItemAdded?.Invoke(this, new ItemEventArgs(item));
        }

        private double GetOccupiedVolume()
        {
            double occupiedVolume = 0;
            foreach (Item item in Contents)
            {
                occupiedVolume += item.Volume;
            }
            return occupiedVolume;
        }
    }

    public class ItemEventArgs : EventArgs
    {
        public Item Item { get; set; }

        public ItemEventArgs(Item item)
        {
            Item = item;
        }
    }

    public class Item
    {
        public string Name { get; set; }
        public double Volume { get; set; }

        public Item(string name, double volume)
        {
            Name = name;
            Volume = volume;
        }
    }
}
