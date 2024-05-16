using Godot;
using System;

public partial class Player : CharacterBody3D
{
    [ExportGroup("Required Nodes")] // Groups the exports in GODOT by comment "Required Nodes"
    [Export] private AnimationPlayer animPlayerNode;
    [Export] private Sprite3D spriteNode;

    private Vector2 direction = new();

    public override void _Ready()
    {
        GD.Print(animPlayerNode.Name);
        GD.Print(spriteNode.Name);
    }

    public override void _PhysicsProcess(double delta)
    {   
        Velocity = new(direction.X , 0 , direction.Y);

        Velocity *= 5;

        MoveAndSlide();
    }

    public override void _Input(InputEvent @event)
    {   
        direction = Input.GetVector
        (
            "MoveLeft",
            "MoveRight",
            "MoveBackward",
            "MoveForward"
        );
    }
}
