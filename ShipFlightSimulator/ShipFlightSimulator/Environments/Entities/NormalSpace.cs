﻿using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Route.Result;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Entities;

public class NormalSpace : IEnvironment
{
    private СomparisonResults _comparisonResults;
    public NormalSpace(IReadOnlyCollection<INormalSpaceObstacleObstacle> obstacles, decimal distance)
    {
        Distance = new Distance(distance);
        Obstacles = obstacles;
        _comparisonResults = new СomparisonResults(Obstacles);
    }

    public IReadOnlyCollection<IObstacle> Obstacles { get; }
    public Distance Distance { get; }

    public FlyResult UseShip(IShip ship)
    {
        FlyResult flyResult = ship.PulseEngine.ResultEngine(Distance.Value);
        if (flyResult is not FlyResult.SuccessResult)
        {
            return flyResult;
        }

        FlyResult? comparisonResults = _comparisonResults.ReplacingResults(ship);

        return comparisonResults ?? flyResult;
    }
}