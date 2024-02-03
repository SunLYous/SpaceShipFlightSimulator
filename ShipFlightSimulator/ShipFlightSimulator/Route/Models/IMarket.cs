using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab1.Route.Models;

public interface IMarket
{
    public decimal CalculateCost(IEnumerable<IFuelUsage> fuelUsages);
}