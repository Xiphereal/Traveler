using Godot;

namespace Views;

public partial class Traveler : Control
{
    private Models.Traveler traveler;

    [Export(PropertyHint.Range, "0, 99")]
    private int startingWith = 6;

    public override void _Ready()
    {
        traveler = new Models.Traveler(startingWith);
    }

    public override void _Process(double delta)
    {
        GetNode<Label>("%TravelerCoins").Text = traveler.Coins.ToString();
    }
}
