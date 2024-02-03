using ShipFlightSimulator.Route.Result;

namespace ShipFlightSimulator.Ships.Models.Engines;

public interface IJumpEngine
{
    public FlyResult ResultEngine(decimal distance);
}