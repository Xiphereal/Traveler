using Models;

namespace Control;

public class Asdflasjdhf
{
    private readonly Traveler traveler;

    public Asdflasjdhf(Traveler traveler)
    {
        this.traveler = traveler;
    }

    public bool CanSwap(Item left, Item rigth)
    {
        bool canCarry = traveler.Carries(left) && traveler.Carries(rigth);
        bool canAfford = traveler.CanAfford(left) || traveler.CanAfford(rigth);

        return canCarry || canAfford;
    }
}