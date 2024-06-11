using Godot;
using System;

public partial class PlayerAttackState : PlayerState
{
    [Export] private Timer comboTimerNode;

    private int comboCounter  = 1;
    private int maxComboCount = 2;

    public override void _Ready()
    {
        base._Ready();

        comboTimerNode.Timeout += () => comboCounter = 1;
    }

    protected override void EnterState()
    {
        characterNode.AnimPlayerNode.Play(GameConstants.ANIM_ATTACK + comboCounter);

        characterNode.AnimPlayerNode.AnimationFinished += HandleAnimationFinished;
    }

    protected override void ExitState()
    {
        characterNode.AnimPlayerNode.AnimationFinished -= HandleAnimationFinished;
        comboTimerNode.Start();
    }

    private void HandleAnimationFinished(StringName animName)
    {
        comboCounter++;

        comboCounter = Mathf.Wrap(comboCounter,1,maxComboCount + 1);

        characterNode.StateMachineNode.SwitchState<PlayerIdleState>();

    }
}
