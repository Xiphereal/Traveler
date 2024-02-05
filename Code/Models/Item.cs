namespace Models
{
    public class Item
    {
        public int Cost { get; private set; }


        public static Item Water()
        {
            return new Item() { Cost = 2 };
        }
        public static Item Food()
        {
            return new Item() { Cost = 3 };
        }
    }
}
