using Itmo.ObjectOrientedProgramming.Lab1.Environments.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Models.Obstacles;
using ShipFlightSimulator.Environments.Models;
using ShipFlightSimulator.Environments.Models.Obstacles;
using ShipFlightSimulator.Route.Result;
using ShipFlightSimulator.Ships.Entities;

namespace ShipFlightSimulator.Environments.Entities;

public class NebulaeIncreasedDensityOfSpace : IEnvironment
{
    private СomparisonResults _сomparisonResults;

    public NebulaeIncreasedDensityOfSpace(
        IReadOnlyCollection<INebulaeIncreasedDensitySpaceObstacle> obstacles,
        decimal distance)
    {
        Distance = new Distance(distance);
        Obstacles = obstacles;
        _сomparisonResults = new СomparisonResults(Obstacles);
    }

    public IReadOnlyCollection<IObstacle> Obstacles { get; }
    public Distance Distance { get; }

    public FlyResult UseShip(IShip ship)
    {
        if (ship is not IShipWithJumpEngine jumpEngineShip)
        {
            return new FlyResult.ImpossibleFly();
        }

        FlyResult flyResult = jumpEngineShip.JumpEngine.ResultEngine(Distance.Value);
        if (flyResult is not FlyResult.SuccessResult)
        {
            return flyResult;
        }

        FlyResult? comparisonResults = _сomparisonResults.ReplacingResults(ship);
        return comparisonResults ?? flyResult;
    }
}