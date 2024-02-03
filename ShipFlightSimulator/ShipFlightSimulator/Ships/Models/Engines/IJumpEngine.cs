using Itmo.ObjectOrientedProgramming.Lab1.Route.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Engines;

public interface IJumpEngine
{
    public FlyResult ResultEngine(decimal distance);
}