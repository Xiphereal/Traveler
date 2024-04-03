using System;
using System.Collections.Generic;

namespace Models
{
    public class Traveler
    {
        public readonly HashSet<Item> backpack = new();

        public Traveler(int startingWith = 0)
        {
            Coins = startingWith;
        }

        public int Coins { get; set; }

        public void Earn(int coins)
        {
            Coins += coins;
        }

        public void Spend(int coins)
        {
            Coins -= coins;
        }

        public void Buy(Item item)
        {
            if (CanAfford(item))
            {
                Coins -= item.Cost;
                backpack.Add(item);
            }
        }

        public bool CanAfford(Item item)
        {
            if (item.IsNull())
                return false;

            return item.Cost <= Coins;
        }

        public bool Carries(Item item)
        {
            return item.IsNull() || backpack.Contains(item);
        }

        public void Owns(Item item)
        {
            if (item.Equals(Item.Delivery())
                && backpack.Contains(item))
            {
                throw new ArgumentException("Todavía no se soporta que " +
                    "hayan más de 1 Delivery simultáneo");
            }

            backpack.Add(item);
        }

        public void Travel()
        {
            backpack.RemoveWhere(item =>
                item.Name == Item.Water().Name || item.Name == Item.Food().Name);
        }
    }
}