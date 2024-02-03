using Itmo.ObjectOrientedProgramming.Lab1.Route.Result;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Entities;

public interface IEnvironment
{
    public FlyResult UseShip(IShip ship);
}