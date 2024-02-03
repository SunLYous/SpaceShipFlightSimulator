using ShipFlightSimulator.Environments.Models;
using ShipFlightSimulator.Ships.Models.Engines;
using ShipFlightSimulator.Ships.Models.HullStrengthClasses;

namespace ShipFlightSimulator.Ships.Entities;

public interface IShip
{
    public IHull Hull { get; }
    public IPulseEngine PulseEngine { get; }

    public DamageResult Defence(decimal damage);
}