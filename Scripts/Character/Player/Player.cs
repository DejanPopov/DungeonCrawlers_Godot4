using Godot;
using System;

public partial class Player : CharacterBody3D
{
    [ExportGroup("Required Nodes")]
    [Export] public AnimationPlayer AnimPlayerNode   {get; private set;}
    [Export] public Sprite3D        SpriteNode       {get; private set;}
    [Export] public StateMachine    StateMachineNode {get; private set;}


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
}
