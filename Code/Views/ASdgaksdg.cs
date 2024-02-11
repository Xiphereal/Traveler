using Godot;
using Models;
using System;
using System.Linq;
using static Godot.TextureRect;

namespace Views;

public partial class ASdgaksdg : Control
{
    [Export]
    private int id;

    [Export]
    private Supply supply;

    [Export]
    private Texture2D itemDefinedInEditor;
    private TextureRect textureRect;

    [Signal]
    public delegate void ItemAppearedEventHandler(ASdgaksdg item);

    public Models.Item Item { get; internal set; }

    public override void _Ready()
    {
        Item = supply switch
        {
            Supply.Food => Models.Item.Food(id),
            Supply.Water => Models.Item.Water(id),
            _ => throw new ArgumentException(),
        };

        // Lo suyo es hacer esto con la API de Godot bien, pero no termino de saber como utilizarla.
        textureRect = GetChildren().OfType<TextureRect>().Single();
        textureRect.Texture = itemDefinedInEditor;

        EmitSignal(SignalName.ItemAppeared, this);
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
        return Traveler().Carries(Item) || Traveler().CanAfford(Item);
    }

    private Traveler Traveler() =>
        GetNode<TravelerView>("/root/Node2D/UI/Backpack").Traveler;

    public override void _DropData(Vector2 atPosition, Variant data)
    {
        var targetItem = (ASdgaksdg)data;

        if (!Traveler().Carries(targetItem.Item))
        {
            Traveler().Buy(targetItem.Item);
            GetChildren().OfType<AudioStreamPlayer>().Single().Play();
        }

        SwapItemWith(targetItem);
    }

    private void SwapItemWith(ASdgaksdg other)
    {
        // Ojo que esto solo cambia las texturas. Los items no se mueven
        // desde que se inicializa la escena. Esto me va a joder la vida
        // en algún momento.
        (other.textureRect.Texture, textureRect.Texture) =
            (textureRect.Texture, other.textureRect.Texture);
    }
}