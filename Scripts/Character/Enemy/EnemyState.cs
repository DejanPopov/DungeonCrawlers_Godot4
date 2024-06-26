using System;
using Godot;

public abstract partial class EnemyState : CharacterState
{
    protected Vector3 destination;

    public override void _Ready()
    {
        base._Ready();

        characterNode.GetStatResource(Stat.Health).onZero += HandleZeroHealth;
    }

    private void HandleZeroHealth()
    {
        characterNode.StateMachineNode.SwitchState<EnemyDeathState>();
    }

    protected Vector3 GetPointGlobalPosition(int index)
    {
        Vector3 localPos  = characterNode.PathNode.Curve.GetPointPosition(index);
        Vector3 globasPos = characterNode.PathNode.GlobalPosition;
        return localPos + globasPos;
    }


    protected void Move()
    {
        characterNode.AgentNode.GetNextPathPosition();
        characterNode.Velocity = characterNode.GlobalPosition.DirectionTo(destination);
        characterNode.MoveAndSlide();
        characterNode.Flip();
    }

    protected void HandleChaseAreaBodyEntered(Node3D body)
    {
        characterNode.StateMachineNode.SwitchState<EnemyChaseState>();
    }
}