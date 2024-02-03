using ShipFlightSimulator.Environments.Models;
using ShipFlightSimulator.Ships.Models.Deflectors;
using ShipFlightSimulator.Ships.Models.Engines;
using ShipFlightSimulator.Ships.Models.HullStrengthClasses;

namespace ShipFlightSimulator.Ships.Entities;

public class VaclasShip : IShip, IShipWithDeflector, IShipWithJumpEngine
{
    public VaclasShip(ClassEPulseEngine pulseEngine, GammaJumpEngine jumpEngine, IDeflector deflector, SecondClassHull hull)
    {
        PulseEngine = pulseEngine;
        JumpEngine = jumpEngine;
        Deflector = deflector;

        Hull = hull;
    }

    public IDeflector Deflector { get; }
    public IHull Hull { get; }
    public IPulseEngine PulseEngine { get; }
    public IJumpEngine JumpEngine { get; }
    public DamageResult Defence(decimal damage)
    {
        if (Deflector.HitPoints.IntegrityCheck())
        {
            DamageResult resultDeflector = Deflector.TakeDamage(damage);
            switch (resultDeflector)
            {
                case DamageResult.Success:
                    return resultDeflector;
                case DamageResult.Destruction destruction:
                    return Hull.TakeDamage(destruction.RemainingDamage);
            }
        }

        return Hull.TakeDamage(damage);
    }
}