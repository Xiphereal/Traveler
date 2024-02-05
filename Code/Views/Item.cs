using Godot;
using System;

namespace Views;

public partial class Item : Label
{
    [Export]
    private Supply supply;

    public override void _Ready()
    {
        Text = supply switch
        {
            Supply.Food => Models.Item.Food().Cost.ToString(),
            Supply.Water => Models.Item.Water().Cost.ToString(),
            _ => throw new ArgumentException(),
        };
    }
}

public enum Supply
{
    Food,
    Water,
}