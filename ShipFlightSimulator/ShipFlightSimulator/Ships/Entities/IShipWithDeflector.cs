using ShipFlightSimulator.Ships.Models.Deflectors;

namespace ShipFlightSimulator.Ships.Entities;

public interface IShipWithDeflector
{
    public IDeflector Deflector { get; }
}