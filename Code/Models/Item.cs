using System;

namespace Models
{
    public class Item
    {
        private readonly int id;

        public Item(string name, int? id = null)
        {
            this.id = id is null ? new Random().Next(1, 9999) : id.Value;
            Name = name;
        }

        public int Cost { get; private set; }

        public string Name { get; private set; }

        public static Item Null() => new("null");
        public static Item Water(int? id = null) => new("Water", id) { Cost = 2 };
        public static Item Food(int? id = null) => new("Food", id) { Cost = 3 };
        public static Item Map(int? id = null) => new("Map", id);
        public static Item CostlyOne() => new("CostlyOne") { Cost = 99999999 };

        public override bool Equals(object obj)
        {
            return obj is Item item &&
                id.Equals(item.id);
        }
    }
}
