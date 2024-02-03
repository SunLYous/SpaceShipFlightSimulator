using ShipFlightSimulator.Environments.Models;

namespace ShipFlightSimulator.Ships.Models.HullStrengthClasses;

public interface IHull
{
    public HitPoints HitPoints { get; }

    public DamageResult TakeDamage(decimal damage);
}