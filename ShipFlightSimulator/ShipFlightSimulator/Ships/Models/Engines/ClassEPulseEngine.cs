using ShipFlightSimulator.Route.Models;
using ShipFlightSimulator.Route.Result;

namespace ShipFlightSimulator.Ships.Models.Engines;

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