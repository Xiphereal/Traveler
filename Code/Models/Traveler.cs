namespace Models
{
    public class Traveler
    {
        public Traveler(int startingWith = 0)
        {
            Coins = startingWith;
        }

        public int Coins { get; private set; }

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
            if (item.Cost <= Coins)
                Coins -= item.Cost;
        }
    }
}