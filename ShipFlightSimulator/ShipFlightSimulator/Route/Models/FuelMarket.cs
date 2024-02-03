namespace ShipFlightSimulator.Route.Models;

public class FuelMarket : IMarket
{
    private const int ActivePlasmaPrice = 3;
    private const int GravitationalMatterPrice = 6;

    public decimal CalculateCost(IEnumerable<IFuelUsage> fuelUsages)
    {
        return fuelUsages.Sum(fuelUsage =>
        {
            return fuelUsage switch
            {
                GravitationalMatterUsage => fuelUsage.Usage * GravitationalMatterPrice,
                ActivePlasmaUsage => fuelUsage.Usage * ActivePlasmaPrice,
                _ => 0,
            };
        });
    }
}