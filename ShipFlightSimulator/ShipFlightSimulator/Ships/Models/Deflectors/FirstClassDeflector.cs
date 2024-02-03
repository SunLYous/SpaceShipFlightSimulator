using ShipFlightSimulator.Environments.Models;

namespace ShipFlightSimulator.Ships.Models.Deflectors;

public class FirstClassDeflector : IDeflector
{
    public FirstClassDeflector()
    {
        HitPoints = new HitPoints();
    }

    public HitPoints HitPoints { get; }

    public DamageResult TakeDamage(decimal damage)
    {
        {
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
}