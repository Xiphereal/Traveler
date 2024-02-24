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
        {
            ownedItems = new Array<Texture2D>(
                Persistence().OwnedItems.Select(item => item.ToTexture()));
            Traveler.Coins = Persistence().Coins;
        }

        foreach (var item in ownedItems)
            PutInBackpack(item);
    }

    private void PutInBackpack(Texture2D item)
    {
        var backpack = GetAllDescendantsOf(this).OfType<GridContainer>().Single();

        backpack.GetChildren()
            .OfType<ASdgaksdg>().First()
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
