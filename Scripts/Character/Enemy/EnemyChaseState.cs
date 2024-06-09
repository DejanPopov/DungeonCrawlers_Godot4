using Godot;
using System;
using System.Linq;

public partial class EnemyChaseState : EnemyState
{

    private CharacterBody3D target;
    protected override void EnterState()
    {
        characterNode.AnimPlayerNode.Play(GameConstants.ANIM_MOVE);
        target = characterNode.ChaseAreaNode.GetOverlappingBodies().First() as CharacterBody3D;
    }

    public override void _PhysicsProcess(double delta)
    {
        destination = target.GlobalPosition;
        characterNode.AgentNode.TargetPosition = destination;
        Move();
    }


}

