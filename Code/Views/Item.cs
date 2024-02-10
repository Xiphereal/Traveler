using Godot;
using System;

namespace Views;

public partial class Item : Label
{
    [Export]
    private Supply supply;

    public Models.Item Model { get; private set; }

    public override void _Ready()
    {
        Model = supply switch
        {
            Supply.Food => Models.Item.Food(),
            Supply.Water => Models.Item.Water(),
            _ => throw new ArgumentException(),
        };

        Text = Model.Cost.ToString();
    }
}

public enum Supply
{
    Food,
    Water,
}