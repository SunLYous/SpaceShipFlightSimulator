using Itmo.ObjectOrientedProgramming.Lab1.Environments.Models.Obstacles;
using ShipFlightSimulator.Ships.Entities;
using ShipFlightSimulator.Ships.Models.Deflectors;

namespace ShipFlightSimulator.Environments.Models.Obstacles;

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