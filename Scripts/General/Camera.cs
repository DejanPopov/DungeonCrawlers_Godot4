using Godot;
using System;

public partial class Camera : Camera3D
{
    [Export] private Node target;
    [Export] private Vector3 positionFromTarget;

    public override void _Ready()
    {
        GameEvents.onStartGame += HandleStartGame;
        GameEvents.onStartGame += HandleEndGame;
    }

    private void HandleEndGame()
    {
        Reparent(GetTree().CurrentScene);
    }

    private void HandleStartGame()
    {
        Reparent(target);
        Position = positionFromTarget;
    }
}
