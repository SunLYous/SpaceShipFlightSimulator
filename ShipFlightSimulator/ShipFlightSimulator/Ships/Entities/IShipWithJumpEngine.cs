using ShipFlightSimulator.Ships.Models.Engines;

namespace ShipFlightSimulator.Ships.Entities;

public interface IShipWithJumpEngine
{
    public IJumpEngine JumpEngine { get; }
}