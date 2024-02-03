using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Route.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Route.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Engines;

public class ClassCPulseEngine : IPulseEngine
{
    private const decimal Speed = 20;
    private const decimal StartFuel = 5;
    private const decimal FuelConsumption = 10;

    public FlyResult ResultEngine(decimal distance)
    {
        return new FlyResult.SuccessResult(
            distance / Speed,
            new List<IFuelUsage> { new ActivePlasmaUsage((distance * FuelConsumption) + StartFuel) });
    }
}