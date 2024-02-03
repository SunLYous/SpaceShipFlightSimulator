using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Deflectors;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

public interface IShipWithDeflector
{
    public IDeflector Deflector { get; }
}