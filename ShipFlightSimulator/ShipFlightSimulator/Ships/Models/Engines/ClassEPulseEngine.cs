using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Route.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Route.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Engines;

public class ClassEPulseEngine : IPulseEngine, IFlyNitrideParticles
{
    private const int StartFuel = 10;
    private const int FuelConsumption = 20;

    public FlyResult ResultEngine(decimal distance)
    {
        return new FlyResult.SuccessResult(
            (decimal)Math.Log((double)distance),
            new List<IFuelUsage> { new ActivePlasmaUsage((distance * FuelConsumption) + StartFuel) });
    }
}