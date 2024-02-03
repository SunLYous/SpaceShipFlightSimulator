using ShipFlightSimulator.Environments.Models;

namespace ShipFlightSimulator.Ships.Models.Deflectors;

public interface IDeflector
{
    public HitPoints HitPoints { get; }

    public DamageResult TakeDamage(decimal damage);
}