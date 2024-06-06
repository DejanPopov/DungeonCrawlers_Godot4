using Godot;
using System;

public partial class EnemyPatrolState : EnemyState
{
    protected override void EnterState()
    {
        characterNode.AnimPlayerNode.Play(GameConstants.ANIM_MOVE);

        destination = GetPointGlobalPosition(1);
        characterNode.AgentNode.TargetPosition = destination;
    }

    public override void _PhysicsProcess(double delta)
    {
        Move();
    }
}
