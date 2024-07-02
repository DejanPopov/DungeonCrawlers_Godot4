using Godot;
using System;

public partial class EnemyCountLabel : Label
{
    public override void _Ready()
    {
        GameEvents.onNewEnemyCount += HandleNewEnemyCount;
    }

    private void HandleNewEnemyCount(int count)
    {
        Text = count.ToString();
    }
}
