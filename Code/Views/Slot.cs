using Control;
using Godot;
using Models;
using System;
using System.Linq;
using Views.Extensions;
using static Godot.TextureRect;

namespace Views
{

    public partial class Slot : Godot.Control
    {
        [Export]
        private Supply supply;

        [Export]
        private Texture2D itemDefinedInEditor;
        internal TextureRect textureRect;

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

        private static Godot.Control CenteredOnMouse(TextureRect itemBeingDragged)
        {
            var control = new Godot.Control();
            control.AddChild(itemBeingDragged);

            itemBeingDragged.Position = -0.5f * itemBeingDragged.CustomMinimumSize;

            return control;
        }

        public override bool _CanDropData(Vector2 atPosition, Variant data)
        {
            var targetSlot = (Slot)data;

            var sadfasdf = new Asdflasjdhf(Traveler());

            return !targetSlot.Item.Equals(Item)
                && sadfasdf.CanSwap(Item, targetSlot.Item);
        }

        private Traveler Traveler() =>
            GetNode<TravelerView>("/root/Node2D/UI/Backpack").Traveler;

        public override void _DropData(Vector2 atPosition, Variant data)
        {
            var targetSlot = (Slot)data;

            if (Traveler().Carries(targetSlot.Item) || !targetSlot.HasItem())
            {
                GetChildren().OfType<AudioStreamPlayer>().Single()
                    .Play("res://Assets/SFX/DropItem.wav");
            }
            else
            {
                Traveler().Buy(targetSlot.Item);
                GetChildren().OfType<AudioStreamPlayer>().Single()
                    .Play("res://Assets/SFX/CoinsRattle.wav");
            }

            SwapItemWith(targetSlot);
        }

        public bool HasItem()
        {
            return !Item.IsNull();
        }

        private void SwapItemWith(Slot other)
        {
            (other.textureRect.Texture, textureRect.Texture) =
                (textureRect.Texture, other.textureRect.Texture);

            (other.Item, Item) = (Item, other.Item);
        }
    }
}