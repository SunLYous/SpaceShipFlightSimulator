using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Models.Obstacles;

public class Meteorite : INormalSpaceObstacleObstacle
{
    private const int NetDamage = 50;
    public DamageResult DealDamage(IShip ship)
    {
        return ship.Defence(NetDamage);
    }
}