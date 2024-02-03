using ShipFlightSimulator.Route.Result;
using ShipFlightSimulator.Ships.Entities;

namespace ShipFlightSimulator.Environments.Entities;

public interface IEnvironment
{
    public FlyResult UseShip(IShip ship);
}