namespace Itmo.ObjectOrientedProgramming.Lab1.Route.Models;

public class GravitationalMatterUsage : IFuelUsage
{
    public GravitationalMatterUsage(decimal usage)
    {
        Usage = usage;
    }

    public decimal Usage { get; }
}