namespace Models
{
    public class Villager
    {
        public static void GiveDelivery(Traveler to)
        {
            to.Owns(Item.Delivery());
        }
    }
}
