using Itmo.ObjectOrientedProgramming.Lab1.Environments.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.HullStrengthClasses;

public interface IHull
{
    public HitPoints HitPoints { get; }

    public DamageResult TakeDamage(decimal damage);
}