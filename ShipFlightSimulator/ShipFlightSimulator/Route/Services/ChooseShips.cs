﻿using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Route.Result;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Route.Services;

public class ChooseShips
{
    public ChooseShips(IReadOnlyCollection<IShip> ships, Route route)
    {
        Route = route;
        Ships = ships;
    }

    public Route Route { get; }
    public IReadOnlyCollection<IShip> Ships { get; }

    public IShip? ChooseBestShip()
    {
        FlyResult.SuccessResult? bestResult = Ships
            .Select(ship => Route.CheckFlyResult(ship))
            .OfType<FlyResult.SuccessResult>()
            .OrderByDescending(result => result.Time)
            .ThenByDescending(result => result.Money)
            .FirstOrDefault();

        return bestResult?.Ship;
    }
}