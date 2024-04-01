using Godot;
using Models;
using System;
using System.Linq;
using Views.Extensions;
using static Godot.TextureRect;

namespace Views;

public partial class ASdgaksdg : Control
{
    [Export]
    private Supply supply;

    [Export]
    private Texture2D itemDefinedInEditor;
    internal TextureRect textureRect;

    [Signal]
    public delegate void ItemAppearedEventHandler(ASdgaksdg item);

    public Models.Item Item { get; internal set; }

    public override void _Ready()
    {
        Item = supply switch
        {
            Supply.Food => Models.Item.Food(),
            Supply.Water => Models.Item.Water(),
            Supply.Null => Models.Item.Null(),
            _ => throw new ArgumentException(),
        };

        // Lo suyo es hacer esto con la API de Godot bien, pero no termino de saber como utilizarla.
        textureRect = GetChildren().OfType<TextureRect>().Single();
        textureRect.Texture = itemDefinedInEditor;
    }

    public override Variant _GetDragData(Vector2 atPosition)
    {
        if (textureRect.Texture is null)
            return new Variant();

        var itemBeingDragged = new TextureRect
        {
            Texture = textureRect.Texture,
            CustomMinimumSize = new Vector2(100, 100),
            ExpandMode = ExpandModeEnum.IgnoreSize,
        };

        GetChildren().OfType<AudioStreamPlayer>().Single()
            .Play("res://Assets/SFX/GrabItem.wav");

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
        var targetSlot = (ASdgaksdg)data;

        return !targetSlot.Item.Equals(Item)
            && (Traveler().Carries(Item) || Traveler().CanAfford(Item));
    }

    private Traveler Traveler() =>
        GetNode<TravelerView>("/root/Node2D/UI/Backpack").Traveler;

    public override void _DropData(Vector2 atPosition, Variant data)
    {
        var targetItem = (ASdgaksdg)data;

        if (Traveler().Carries(targetItem.Item) || targetItem.Item.IsNull())
        {
            GetChildren().OfType<AudioStreamPlayer>().Single()
                .Play("res://Assets/SFX/DropItem.wav");
        }
        else
        {
            Traveler().Buy(targetItem.Item);
            GetChildren().OfType<AudioStreamPlayer>().Single()
                .Play("res://Assets/SFX/CoinsRattle.wav");
        }

        SwapItemWith(targetItem);
    }

    private void SwapItemWith(ASdgaksdg other)
    {
        (other.textureRect.Texture, textureRect.Texture) =
            (textureRect.Texture, other.textureRect.Texture);

        (other.Item, Item) = (Item, other.Item);
    }
}