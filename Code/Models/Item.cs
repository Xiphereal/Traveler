using Models.Utils;

namespace Models
{
    public class Item
    {
        private readonly int id = IdGenerator.NewId();

        public Item(string name)
        {
            Name = name;
        }

        public int Cost { get; private set; }

        public string Name { get; private set; }

        public static Item Null() => new("null");
        public static Item Water() => new("Water") { Cost = 2 };
        public static Item Food() => new("Food") { Cost = 3 };
        public static Item Map() => new("Map");
        public static Item CostlyOne() => new("CostlyOne") { Cost = 99999999 };

        public override bool Equals(object obj)
        {
            return obj is Item item &&
                id.Equals(item.id);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public bool IsNull()
        {
            return Name.Equals(Item.Null().Name);
        }
    }
}
