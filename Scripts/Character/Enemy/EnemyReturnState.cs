using Godot;
using System;

public partial class EnemyReturnState : EnemyState
{
    private Vector3 destination;

    public override void _Ready()
    {
        base._Ready();

        Vector3 localPos  = characterNode.PathNode.Curve.GetPointPosition(0);
        Vector3 globasPos = characterNode.PathNode.GlobalPosition;
        destination = localPos + globasPos;
    }

    protected override void EnterState()
    {
        characterNode.AnimPlayerNode.Play(GameConstants.ANIM_MOVE);


        characterNode.GlobalPosition = destination;
    }
}
