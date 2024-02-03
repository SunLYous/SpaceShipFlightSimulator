using Itmo.ObjectOrientedProgramming.Lab1.Environments.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.HullStrengthClasses;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

public class WalkingShip : IShip
{
    public WalkingShip(ClassCPulseEngine pulseEngine, FirstClassHull hull)
    {
        PulseEngine = pulseEngine;
        Hull = hull;
    }

    public IHull Hull { get; }
    public IPulseEngine PulseEngine { get; }
    public DamageResult Defence(decimal damage)
    {
        return Hull.TakeDamage(damage);
    }
}