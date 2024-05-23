using Godot;
using System;

public partial class Player : CharacterBody3D
{
    [ExportGroup("Required Nodes")]
    [Export] public AnimationPlayer animPlayerNode;
    [Export] public Sprite3D spriteNode;
    [Export] public StateMachine stateMachineNode;

    public Vector2 direction = new();

    public override void _Input(InputEvent @event)
    {   
        direction = Input.GetVector
        (
            GameConstants.INPUT_MOVE_LEFT,
            GameConstants.INPUT_MOVE_RIGHT,
            GameConstants.INPUT_MOVE_BACKWARD,
            GameConstants.INPUT_MOVE_FORWARD
        );
    }

    public void Flip()
    {  
        bool isMovingHorizontally = Velocity.X == 0;

        if (isMovingHorizontally)
        {
            return;
        }

        bool isMovingLeft = Velocity.X < 0;
        spriteNode.FlipH = isMovingLeft;
    }
}
