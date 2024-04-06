namespace Models
{
    public class Villager
    {
        public static void GiveDelivery(Traveler to)
        {
            to.Owns(Item.Delivery());
        }

        public static void AcceptDelivery(Traveler from)
        {
            from.Deliver();
        }
    }
}