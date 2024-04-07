
using Models;

namespace Control;

public class Narrator
{
    private readonly Traveler traveler;

    public Narrator(Traveler traveler)
    {
        this.traveler = traveler;
    }

    public string DoYouHaveSomethingToDeliver()
    {
        return traveler.Carries(Item.Delivery())
            ? "... and you hand the villager the delivery."
            : "... but you find nothing.";
    }
}