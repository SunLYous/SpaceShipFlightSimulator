namespace Itmo.ObjectOrientedProgramming.Lab1.Route.Models;

public class ActivePlasmaUsage : IFuelUsage
{
    public ActivePlasmaUsage(decimal usage)
    {
        Usage = usage;
    }

    public decimal Usage { get; }
}