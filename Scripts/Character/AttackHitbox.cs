using Godot;
using System;

public partial class AttackHitbox : Area3D
{
    public float GetDamage()
    {
        return GetOwner<Character>().GetStatResource(Stat.Strength).StatValue;
    }
}
