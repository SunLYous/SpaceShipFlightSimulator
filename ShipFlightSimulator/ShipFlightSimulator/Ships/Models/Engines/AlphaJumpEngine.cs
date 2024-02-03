using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Route.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Route.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Engines;

public class AlphaJumpEngine : IJumpEngine
{
    private const decimal MaxJump = 300;
    private const decimal JumpTime = 1;
    private const decimal StartFuel = 15;
    public FlyResult ResultEngine(decimal distance)
    {
        if (distance >= MaxJump)
        {
            return new FlyResult.ShipLoss();
        }

        return new FlyResult.SuccessResult(
            JumpTime,
            new List<IFuelUsage> { new GravitationalMatterUsage(distance + StartFuel) });
    }
}