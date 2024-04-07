using Control;
using Godot;

namespace Views;

public partial class Villager : Node
{
    public void GiveDelivery()
    {
        Models.Traveler traveler = Persistence().RetrieveTraveler();
        Models.Villager.GiveDelivery(to: traveler);
        Persistence().Persist(traveler);
    }

    public void AskForDelivery()
    {
        Models.Traveler traveler = Persistence().RetrieveTraveler();

        GetNode<Label>("Result").Text =
            new Narrator(traveler).DoYouHaveSomethingToDeliver();

        Models.Villager.AcceptDelivery(from: traveler);
        Persistence().Persist(traveler);
    }

    private Persistence Persistence() =>
       GetNode<Persistence>($"/root/{nameof(Persistence)}");
}
