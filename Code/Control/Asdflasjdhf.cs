using Models;

namespace Control;

public class Asdflasjdhf
{
    private Traveler traveler;

    public Asdflasjdhf(Traveler traveler)
    {
        this.traveler = traveler;
    }

    public bool CanSwap(Item left, Item rigth)
    {
        return ((traveler.Carries(left) && traveler.Carries(rigth))
            || (traveler.CanAfford(left) || traveler.CanAfford(rigth)));
    }
}
