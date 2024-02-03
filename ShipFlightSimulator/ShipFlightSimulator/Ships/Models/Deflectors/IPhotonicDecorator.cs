namespace ShipFlightSimulator.Ships.Models.Deflectors;

public interface IPhotonicDecorator : IDeflector
{
    public abstract bool HandleAntimatterOutbreak();
}