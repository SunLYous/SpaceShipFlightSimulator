using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Deflectors;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Models.Obstacles;

public class AntimatterFlare : INebulaeIncreasedDensitySpaceObstacle
{
    public DamageResult DealDamage(IShip ship)
    {
        if (ship is not IShipWithDeflector shipWithDeflector)
        {
            return new DamageResult.DeathCrew();
        }

        if (!shipWithDeflector.Deflector.HitPoints.IntegrityCheck() ||
            shipWithDeflector.Deflector is not IPhotonicDecorator deflectorDecorator)
        {
            return new DamageResult.DeathCrew();
        }

        if (!deflectorDecorator.HandleAntimatterOutbreak())
        {
            return new DamageResult.DeathCrew();
        }

        return new DamageResult.Success();
    }
}