using Godot;
using Models;
using System;

namespace Views;

public partial class ASdgaksdg : TextureRect
{
    [Export]
    private int id;

    [Export]
    private Supply supply;

    public Models.Item Item { get; internal set; }

    public override void _Ready()
    {
        Item = supply switch
        {
            Supply.Food => Models.Item.Food(id),
            Supply.Water => Models.Item.Water(id),
            _ => throw new ArgumentException(),
        };
    }

    public override Variant _GetDragData(Vector2 atPosition)
    {
        if (Texture is null)
            return new Variant();

        var itemBeingDragged = new TextureRect
        {
            Texture = Texture,
            CustomMinimumSize = new Vector2(100, 100),
            ExpandMode = ExpandModeEnum.IgnoreSize,
        };

        SetDragPreview(CenteredOnMouse(itemBeingDragged));

        return this;
    }

    private static Control CenteredOnMouse(TextureRect itemBeingDragged)
    {
        var control = new Control();
        control.AddChild(itemBeingDragged);

        itemBeingDragged.Position = -0.5f * itemBeingDragged.CustomMinimumSize;

        return control;
    }

    public override bool _CanDropData(Vector2 atPosition, Variant data)
    {
        return Traveler().Carries(Item) ? true : Traveler().CanAfford(Item);
    }

    private Traveler Traveler() =>
        GetNode<TravelerView>("/root/Node2D/UI/Backpack").Traveler;

    public override void _DropData(Vector2 atPosition, Variant data)
    {
        if (!Traveler().Carries(Item))
            Traveler().Buy(Item);

        SwapItemWith(data);
    }

    private void SwapItemWith(Variant source)
    {
        var other = (TextureRect)source;

        (other.Texture, Texture) = (Texture, other.Texture);
    }
}