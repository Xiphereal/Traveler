using Godot;
using System.Collections.Generic;
using System.Linq;

namespace Views;

public partial class Persistence : Node
{
    public List<Models.Item> OwnedItems { get; internal set; } = new();
    public int Coins { get; private set; }

    public bool HasAnything { get; private set; }

    public void Persist(Models.Traveler traveler)
    {
        HasAnything = true;

        OwnedItems = traveler.backpack.ToList();
        Coins = traveler.Coins;
    }

    public Models.Traveler RetrieveTraveler()
    {
        var traveler = new Models.Traveler(Coins);
        OwnedItems.ForEach(i => traveler.Owns(i));

        return traveler;
    }
}
