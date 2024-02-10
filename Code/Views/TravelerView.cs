using Godot;
using Godot.Collections;
using Models;
using System.Linq;

namespace Views;

public partial class TravelerView : Control
{
    [Export(PropertyHint.Range, "0, 99")]
    private int startingWith = 6;

    [Export(PropertyHint.ArrayType)]
    private Array<ASdgaksdg> items = new();

    public Traveler Traveler { get; private set; }

    public override void _Ready()
    {
        Traveler = new Traveler(startingWith);
        Traveler.Owns(items.Select(x => x.Item));
    }

    public override void _Process(double delta)
    {
        GetNode<Label>("%TravelerCoins").Text = Traveler.Coins.ToString();
    }
}
