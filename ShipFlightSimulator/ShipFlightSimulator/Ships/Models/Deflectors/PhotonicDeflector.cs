using Itmo.ObjectOrientedProgramming.Lab1.Environments.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Deflectors;

public class PhotonicDeflector : IPhotonicDecorator
{
    private const int NumberOfCharges = 3;
    private IDeflector _deflector;

    public PhotonicDeflector(IDeflector deflector)
    {
        _deflector = deflector;
    }

    public HitPoints HitPoints => _deflector.HitPoints;

    private int AntimatterOutbreakAmount { get; set; } = NumberOfCharges;

    public bool HandleAntimatterOutbreak()
    {
        if (AntimatterOutbreakAmount <= 0) return false;
        AntimatterOutbreakAmount--;
        return true;
    }

    public DamageResult TakeDamage(decimal damage)
    {
        return _deflector.TakeDamage(damage);
    }
}