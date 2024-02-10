using System;

namespace Models
{
    public class Item
    {
        private int id;

        public Item(int? id = null)
        {
            this.id = id is null ? new Random().Next(1, 9999) : id.Value;
        }

        public int Cost { get; private set; }

        public static Item Water(int? id = null) => new(id) { Cost = 2 };

        public static Item Food(int? id = null) => new(id) { Cost = 3 };

        public static Item CostlyOne() => new() { Cost = 99999999 };

        public override bool Equals(object obj)
        {
            return obj is Item item &&
                id.Equals(item.id);
        }
    }
}
