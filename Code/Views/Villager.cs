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

    private Persistence Persistence() =>
       GetNode<Persistence>($"/root/{nameof(Persistence)}");
}
