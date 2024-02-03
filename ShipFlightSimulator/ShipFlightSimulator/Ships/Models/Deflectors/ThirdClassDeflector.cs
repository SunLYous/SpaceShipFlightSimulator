using ShipFlightSimulator.Environments.Models;

namespace ShipFlightSimulator.Ships.Models.Deflectors;

public class ThirdClassDeflector : IDeflector
{
    private const decimal DamageGradationCoefficient = 0.5m;

    public ThirdClassDeflector()
    {
        HitPoints = new HitPoints();
    }

    public HitPoints HitPoints { get; }

    public DamageResult TakeDamage(decimal damage)
    {
        damage *= DamageGradationCoefficient;
        if (HitPoints.Value < damage)
        {
            damage -= HitPoints.Value;
            HitPoints.TakeDamage(HitPoints.Value);
            return new DamageResult.Destruction(damage);
        }

        HitPoints.TakeDamage(damage);
        return new DamageResult.Success();
    }
}