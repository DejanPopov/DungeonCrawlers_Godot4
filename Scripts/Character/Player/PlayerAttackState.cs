using Godot;
using System;

public partial class PlayerAttackState : PlayerState
{
    private int comboCounter  = 1;
    private int maxComboCount = 2;

    protected override void EnterState()
    {
        characterNode.AnimPlayerNode.Play(GameConstants.ANIM_ATTACK + comboCounter);

        characterNode.AnimPlayerNode.AnimationFinished += HandleAnimationFinished;
    }

    protected override void ExitState()
    {
        characterNode.AnimPlayerNode.AnimationFinished -= HandleAnimationFinished;
    }

    private void HandleAnimationFinished(StringName animName)
    {
        comboCounter++;

        comboCounter = Mathf.Wrap(comboCounter,1,maxComboCount + 1);

        characterNode.StateMachineNode.SwitchState<PlayerIdleState>();

    }
}
