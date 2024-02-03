using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Route.Result;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Entities;

public class NebulaeNitrideParticles : IEnvironment
{
    private СomparisonResults _сomparisonResults;
    public NebulaeNitrideParticles(IReadOnlyCollection<INebulaeNitrideParticlesObstacle> obstacles, decimal distance)
    {
        Distance = new Distance(distance);
        Obstacles = obstacles;
        _сomparisonResults = new СomparisonResults(Obstacles);
    }

    public IReadOnlyCollection<IObstacle> Obstacles { get; }
    public Distance Distance { get; }

    public FlyResult UseShip(IShip ship)
    {
        if (ship.PulseEngine is not IFlyNitrideParticles)
        {
            return new FlyResult.ShipLoss();
        }

        FlyResult flyResult = ship.PulseEngine.ResultEngine(Distance.Value);
        if (flyResult is not FlyResult.SuccessResult)
        {
            return flyResult;
        }

        FlyResult? comparisonResults = _сomparisonResults.ReplacingResults(ship);

        return comparisonResults ?? flyResult;
    }
}