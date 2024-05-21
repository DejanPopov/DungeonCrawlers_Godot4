using Godot;
using System;

public partial class PlayerDashState : Node
{
    private Player characterNode;

    public override void _Ready()
    {
        characterNode = GetOwner<Player>();
    }

    public override void _Notification(int what)
    {
        base._Notification(what);

        if (what == 5001)
        {
            characterNode.animPlayerNode.Play(GameConstants.ANIM_DASH);
            SetPhysicsProcess(true);
        }
    }
}
