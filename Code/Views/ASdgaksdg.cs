using Godot;

public partial class ASdgaksdg : TextureRect
{
    public override Variant _GetDragData(Vector2 atPosition)
    {
        var itemBeingDragged = new TextureRect
        {
            Texture = Texture,
            CustomMinimumSize = new Vector2(200, 200),
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
        return base._CanDropData(atPosition, data);
    }

    public override void _DropData(Vector2 atPosition, Variant data)
    {
        base._DropData(atPosition, data);
    }
}