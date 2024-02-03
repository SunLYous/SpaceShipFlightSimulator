using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Models.Obstacles;

public class SpaceWhales : INebulaeNitrideParticlesObstacle
{
    private const int NetDamage = 260;

    public SpaceWhales(int spaceWhileAmount)
    {
        if (spaceWhileAmount <= 0)
        {
            throw new InvalidValueException("Invalid value detected: the value must be greater than 0");
        }

        Damage = NetDamage * spaceWhileAmount;
    }

    public int Damage { get; }

    public DamageResult DealDamage(IShip ship)
    {
        if (ship is IShipWithAntiNeutrinoEmitter)
        {
            return new DamageResult.Success();
        }

        return ship.Defence(Damage);
    }
}