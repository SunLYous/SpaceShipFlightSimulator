namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Deflectors;

public interface IPhotonicDecorator : IDeflector
{
    public abstract bool HandleAntimatterOutbreak();
}