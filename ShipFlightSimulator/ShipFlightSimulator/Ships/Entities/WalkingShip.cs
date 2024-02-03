using ShipFlightSimulator.Environments.Models;
using ShipFlightSimulator.Ships.Models.Engines;
using ShipFlightSimulator.Ships.Models.HullStrengthClasses;

namespace ShipFlightSimulator.Ships.Entities;

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