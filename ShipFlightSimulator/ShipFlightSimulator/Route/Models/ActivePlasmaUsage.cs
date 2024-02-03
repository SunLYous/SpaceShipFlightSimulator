namespace ShipFlightSimulator.Route.Models;

public class ActivePlasmaUsage : IFuelUsage
{
    public ActivePlasmaUsage(decimal usage)
    {
        Usage = usage;
    }

    public decimal Usage { get; }
}