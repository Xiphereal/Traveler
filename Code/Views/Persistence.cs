using Godot;
using System.Collections.Generic;
using System.Linq;

namespace Views;

public partial class Persistence : Node
{
    public List<Models.Item> OwnedItems { get; internal set; }
    public int Coins { get; private set; }

    public void Persist(Models.Traveler traveler)
    {
        OwnedItems = traveler.backpack.ToList();
        Coins = traveler.Coins;
    }
}
