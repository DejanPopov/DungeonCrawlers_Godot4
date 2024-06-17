using System;
using Godot;
using System.Linq;

public abstract partial class Character : CharacterBody3D
{
    [Export] private StatResource[] stats;

    [ExportGroup("Required Nodes")]
    [Export] public AnimationPlayer AnimPlayerNode   {get; private set;}
    [Export] public Sprite3D        SpriteNode       {get; private set;}
    [Export] public StateMachine    StateMachineNode {get; private set;}
    [Export] public Area3D          HurtBoxNode      {get; private set;}
    [Export] public Area3D          HitBoxNode       {get; private set;}

    [ExportGroup("AI Nodes")]
    [Export] public NavigationAgent3D AgentNode      {get; private set;} 
    [Export] public Path3D            PathNode       {get; private set;}
    [Export] public Area3D            ChaseAreaNode  {get; private set;}
    [Export] public Area3D            AttackAreaNode {get; private set;}

    public Vector2 direction = new();

    public override void _Ready()
    {
        HurtBoxNode.AreaEntered += HandleHurtboxEntered;
    }

    private void HandleHurtboxEntered(Area3D area)
    {
        StatResource health = GetStatResource(Stat.Health);

        Character player = area.GetOwner<Character>();
        health.StatValue -= player.GetStatResource(Stat.Strength).StatValue;
    }

    public StatResource GetStatResource(Stat stat)
    {
        return stats.Where((element) => element.StatType == stat).FirstOrDefault();
    }

    public void Flip()
    {  
        bool isMovingHorizontally = Velocity.X == 0;

        if (isMovingHorizontally)
        {
            return;
        }

        bool isMovingLeft = Velocity.X < 0;
        SpriteNode.FlipH = isMovingLeft;
    }

}