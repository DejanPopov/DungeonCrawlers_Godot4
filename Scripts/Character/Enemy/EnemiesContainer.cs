using Godot;
using System;

public partial class EnemiesContainer : Node3D
{
    public override void _Ready()
    {
        int totalEnemies = GetChildCount();
        GameEvents.RaiseNewEnemyCount(totalEnemies);
    }
}
