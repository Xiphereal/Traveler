using Godot;

namespace Views;

public partial class Villager : Node
{
    public void GiveDelivery()
    {
        Models.Villager.GiveDelivery(to: Persistence().RetrieveTraveler());
    }

    private Persistence Persistence() =>
       GetNode<Persistence>($"/root/{nameof(Persistence)}");
}
