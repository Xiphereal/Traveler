using Godot;
using Models;

namespace Views;

public partial class TravelerView : Control
{
    [Export(PropertyHint.Range, "0, 99")]
    private int startingWith = 6;

    public Traveler Traveler { get; private set; }

    public override void _Ready()
    {
        Traveler = new Traveler(startingWith);
    }

    public override void _Process(double delta)
    {
        GetNode<Label>("%TravelerCoins").Text = Traveler.Coins.ToString();
    }
}