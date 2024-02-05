namespace Models
{
    public class Traveler
    {
        public int Coins { get; private set; }

        public void Earn(int coins)
        {
            Coins += coins;
        }

        public void Spend(int coins)
        {
            Coins -= coins;
        }
    }
}