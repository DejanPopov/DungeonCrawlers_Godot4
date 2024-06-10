using Godot;
using System;
using System.Linq;

public partial class EnemyChaseState : EnemyState
{
    [Export] private Timer timerNode;
    private CharacterBody3D target;

        public override void _PhysicsProcess(double delta)
    {
        Move();
    }

    protected override void EnterState()
    {
        characterNode.AnimPlayerNode.Play(GameConstants.ANIM_MOVE);
        target = characterNode.ChaseAreaNode.GetOverlappingBodies().First() as CharacterBody3D;
        timerNode.Timeout += HandleTimeout;
        characterNode.AttackAreaNode.BodyEntered += HandleAttackAreaBodyEntered;
        characterNode.ChaseAreaNode.BodyExited += HandleChaseAreaBodyExisted;
    }

        protected override void ExitState()
    {
        timerNode.Timeout -= HandleTimeout;
        characterNode.AttackAreaNode.BodyEntered -= HandleAttackAreaBodyEntered;
        characterNode.ChaseAreaNode.BodyExited -= HandleChaseAreaBodyExisted;
    }

    private void HandleChaseAreaBodyExisted(Node3D body)
    {
        characterNode.StateMachineNode.SwitchState<EnemyReturnState>();
    }

    private void HandleAttackAreaBodyEntered(Node3D body)
    {
        characterNode.StateMachineNode.SwitchState<EnemyAttackState>();
    }

    private void HandleTimeout()
    {
        destination = target.GlobalPosition;
        characterNode.AgentNode.TargetPosition = destination;
    }




}

