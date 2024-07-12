using Godot;
using System;

public partial class AbillityHitbox : Area3D, IHitbox
{
    public float GetDamage() => GetOwner<Ability>().Damage;
}
