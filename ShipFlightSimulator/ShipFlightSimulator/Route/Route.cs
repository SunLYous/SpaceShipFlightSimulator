using ShipFlightSimulator.Environments.Entities;
using ShipFlightSimulator.Route.Models;
using ShipFlightSimulator.Route.Result;
using ShipFlightSimulator.Ships.Entities;

namespace ShipFlightSimulator.Route;

public class Route
{
    public Route(IReadOnlyCollection<IEnvironment> environments)
    {
        Environments = environments;
    }

    public IReadOnlyCollection<IEnvironment> Environments { get; }
    public FlyResult CheckFlyResult(IShip ship)
    {
        var results = new List<FlyResult.SuccessResult>();

        foreach (IEnvironment environment in Environments)
        {
            FlyResult result = environment.UseShip(ship);
            if (result is not FlyResult.SuccessResult success)
            {
                return result;
            }

            results.Add(success);
        }

        var fuelUsages = new List<IFuelUsage>();
        decimal time = 0;
        foreach (FlyResult.SuccessResult result in results)
        {
            time += result.Time;
            fuelUsages.AddRange(result.FuelUsages);
        }

        var sumResult = new FlyResult.SuccessResult(time: time, fuelUsages,  ship);
        return sumResult;
    }
}