using Godot;

public abstract partial class Character : CharacterBody3D
{
    [ExportGroup("Required Nodes")]
    [Export] public AnimationPlayer AnimPlayerNode   {get; private set;}
    [Export] public Sprite3D        SpriteNode       {get; private set;}
    [Export] public StateMachine    StateMachineNode {get; private set;}

    [ExportGroup("AI Nodes")]
    [Export] public Path3D PathNode {get; private set;}

    public Vector2 direction = new();

    public void Flip()
    {  
        bool isMovingHorizontally = Velocity.X == 0;

        if (isMovingHorizontally)
        {
            return;
        }

        bool isMovingLeft = Velocity.X < 0;
        SpriteNode.FlipH = isMovingLeft;
    }

}