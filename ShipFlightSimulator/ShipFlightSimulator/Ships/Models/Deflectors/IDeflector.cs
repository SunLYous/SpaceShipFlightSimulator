using Itmo.ObjectOrientedProgramming.Lab1.Environments.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Deflectors;

public interface IDeflector
{
    public HitPoints HitPoints { get; }

    public DamageResult TakeDamage(decimal damage);
}