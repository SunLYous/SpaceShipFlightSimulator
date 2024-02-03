using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Route.Result;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Entities;

public class СomparisonResults
{
    private readonly IEnumerable<IObstacle> _obstacles;

    public СomparisonResults(IEnumerable<IObstacle> obstacles)
    {
        _obstacles = obstacles;
    }

    public FlyResult? ReplacingResults(IShip ship)
    {
        foreach (IObstacle obstacle in _obstacles)
        {
            DamageResult damageResult = obstacle.DealDamage(ship);
            switch (damageResult)
            {
                case DamageResult.Destruction:
                    return new FlyResult.DestructionShip();
                case DamageResult.DeathCrew:
                    return new FlyResult.DeathCrew();
            }
        }

        return null;
    }
}