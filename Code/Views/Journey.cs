using Godot;

namespace Views;

public partial class Journey : Node
{
    public void Travel()
    {
        Models.Traveler traveler = Persistence().RetrieveTraveler();
        traveler.Travel();
        Persistence().Persist(traveler);
    }

    private Persistence Persistence() =>
       GetNode<Persistence>($"/root/{nameof(Persistence)}");
}
