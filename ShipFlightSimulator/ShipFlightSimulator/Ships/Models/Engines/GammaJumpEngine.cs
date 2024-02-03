using ShipFlightSimulator.Route.Models;
using ShipFlightSimulator.Route.Result;

namespace ShipFlightSimulator.Ships.Models.Engines;

public class GammaJumpEngine : IJumpEngine
{
    private const decimal MaxJump = 900;
    private const decimal JumpTime = 2;
    private const decimal StartJump = 30;

    public FlyResult ResultEngine(decimal distance)
    {
        if (distance >= MaxJump)
        {
            return new FlyResult.ShipLoss();
        }

        return new FlyResult.SuccessResult(
            JumpTime,
            new List<IFuelUsage> { new GravitationalMatterUsage((distance * distance) + StartJump) });
    }
}