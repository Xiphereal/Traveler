namespace Models
{
    public class Item
    {
        public int Cost { get; private set; }

        public static Item Water() => new() { Cost = 2 };

        public static Item Food() => new() { Cost = 3 };

        public static Item CostlyOne() => new() { Cost = 99999999 };
    }
}
