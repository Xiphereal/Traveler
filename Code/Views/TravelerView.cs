using Godot;
using Godot.Collections;
using Models;
using System.Collections.Generic;
using System.Linq;
using Views.Extensions;

namespace Views;

public partial class TravelerView : Control
{
    [Export(PropertyHint.Range, "0, 99")]
    private int startingWith = 6;

    [Export]
    private Array<Texture2D> ownedItems = new();

    public Traveler Traveler { get; private set; }

    public TravelerView()
    {
        Traveler = new Traveler(startingWith);
    }

    public override void _Ready()
    {
        if (Persistence().HasAnything)
            RetrieveFrom(Persistence());

        for (int i = 0; i < ownedItems.Count; i++)
            PutInBackpack(ownedItems[i], at: i);
    }

    private void RetrieveFrom(Persistence persistence)
    {
        ownedItems = new Array<Texture2D>(
            persistence.OwnedItems.Select(item => item.ToTexture()));

        Traveler.Coins = persistence.Coins;
    }

    private void PutInBackpack(Texture2D item, int at)
    {
        Traveler.Owns(item.ToItem());

        var backpack = GetAllDescendantsOf(this).OfType<GridContainer>().Single();
        backpack.GetChildren()
            .OfType<ASdgaksdg>().ElementAt(at)
            .textureRect.Texture = item;
    }

    private static IEnumerable<Node> GetAllDescendantsOf(Node node)
    {
        List<Node> descendants = new();

        foreach (Node child in node.GetChildren())
        {
            descendants.Add(child);
            descendants.AddRange(GetAllDescendantsOf(child));
        }

        return descendants;
    }

    public override void _Process(double delta)
    {
        GetNode<Label>("%TravelerCoins").Text = Traveler.Coins.ToString();
    }

    public void OnSlotReady(ASdgaksdg item)
    {
        Traveler.Owns(item.Item);
    }

    public override void _ExitTree()
    {
        Persistence().Persist(Traveler);
    }

    private Persistence Persistence() =>
        GetNode<Persistence>($"/root/{nameof(Persistence)}");
}
