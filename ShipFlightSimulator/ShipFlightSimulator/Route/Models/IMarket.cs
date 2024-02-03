namespace ShipFlightSimulator.Route.Models;

public interface IMarket
{
    public decimal CalculateCost(IEnumerable<IFuelUsage> fuelUsages);
}