using Godot;
using System;

public partial class AbillityHitbox : Area3D, IHitbox
{
    public bool CanStun()
    {
        return true;
    }

    public float GetDamage() => GetOwner<Ability>().Damage;
}
