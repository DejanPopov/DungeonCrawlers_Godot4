using Godot;
using System;

public partial class AbillityHitbox : Area3D
{
    public float GetDamage() => GetOwner<Bomb>().Damage;
}
