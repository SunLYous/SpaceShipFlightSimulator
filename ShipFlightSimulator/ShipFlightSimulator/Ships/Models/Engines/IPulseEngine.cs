using Itmo.ObjectOrientedProgramming.Lab1.Route.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Engines;

public interface IPulseEngine
{
    public FlyResult ResultEngine(decimal distance);
}