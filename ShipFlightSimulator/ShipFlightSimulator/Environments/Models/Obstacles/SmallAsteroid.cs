﻿using ShipFlightSimulator.Environments.Models;
using ShipFlightSimulator.Environments.Models.Obstacles;
using ShipFlightSimulator.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Models.Obstacles;

public class SmallAsteroid : INormalSpaceObstacleObstacle
{
    private const int NetDamage = 25;

    public DamageResult DealDamage(IShip ship)
    {
        return ship.Defence(NetDamage);
    }
}