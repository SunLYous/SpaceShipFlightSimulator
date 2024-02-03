namespace ShipFlightSimulator.Route.Models;

public class GravitationalMatterUsage : IFuelUsage
{
    public GravitationalMatterUsage(decimal usage)
    {
        Usage = usage;
    }

    public decimal Usage { get; }
}