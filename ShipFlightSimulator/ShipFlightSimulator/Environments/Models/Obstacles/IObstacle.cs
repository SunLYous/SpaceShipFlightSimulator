using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Models.Obstacles;

public interface IObstacle
{
    public DamageResult DealDamage(IShip ship);
}