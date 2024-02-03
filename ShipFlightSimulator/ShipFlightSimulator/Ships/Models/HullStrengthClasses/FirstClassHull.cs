using Itmo.ObjectOrientedProgramming.Lab1.Environments.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.HullStrengthClasses;

public class FirstClassHull : IHull
{
    public FirstClassHull()
    {
        HitPoints = new HitPoints();
    }

    public HitPoints HitPoints { get; }

    public DamageResult TakeDamage(decimal damage)
    {
        HitPoints.TakeDamage(damage);
        if (HitPoints.IntegrityCheck())
        {
            return new DamageResult.Success();
        }

        return new DamageResult.Destruction();
    }
}