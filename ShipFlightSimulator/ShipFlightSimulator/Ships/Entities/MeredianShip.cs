using ShipFlightSimulator.Environments.Models;
using ShipFlightSimulator.Ships.Models.Deflectors;
using ShipFlightSimulator.Ships.Models.Engines;
using ShipFlightSimulator.Ships.Models.HullStrengthClasses;

namespace ShipFlightSimulator.Ships.Entities;

public class MeredianShip : IShipWithAntiNeutrinoEmitter, IShipWithDeflector
{
    public MeredianShip(ClassEPulseEngine pulseEngine, IDeflector deflector, SecondClassHull hull)
    {
        PulseEngine = pulseEngine;
        AntiNeutrinoEmitter = true;
        Deflector = deflector;
        Hull = hull;
    }

    public IDeflector Deflector { get; }
    public IHull Hull { get; }
    public IPulseEngine PulseEngine { get; }
    public bool AntiNeutrinoEmitter { get; }

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