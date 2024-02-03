using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Route.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Route.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Engines;

public class OmegaJumpEngine : IJumpEngine
{
    private const decimal MaxJump = 600;
    private const decimal JumpTime = 1.5m;
    private const decimal StartJump = 25;

    public FlyResult ResultEngine(decimal distance)
    {
        if (distance >= MaxJump)
        {
            return new FlyResult.ShipLoss();
        }

        return new FlyResult.SuccessResult(
            JumpTime,
            new List<IFuelUsage>
            {
                new GravitationalMatterUsage((distance * (decimal)Math.Log((double)distance)) + StartJump),
            });
    }
}