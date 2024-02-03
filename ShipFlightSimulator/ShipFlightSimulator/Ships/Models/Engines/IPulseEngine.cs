using ShipFlightSimulator.Route.Result;

namespace ShipFlightSimulator.Ships.Models.Engines;

public interface IPulseEngine
{
    public FlyResult ResultEngine(decimal distance);
}