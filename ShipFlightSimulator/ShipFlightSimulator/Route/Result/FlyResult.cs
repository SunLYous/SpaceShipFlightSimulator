using ShipFlightSimulator.Route.Models;
using ShipFlightSimulator.Ships.Entities;

namespace ShipFlightSimulator.Route.Result;

public abstract record FlyResult
{
    private FlyResult() { }

    public sealed record DeathCrew : FlyResult;

    public sealed record DestructionShip : FlyResult;

    public sealed record ImpossibleFly : FlyResult;

    public sealed record ShipLoss : FlyResult;

    public sealed record SuccessResult : FlyResult
    {
        public SuccessResult(decimal time, IReadOnlyCollection<IFuelUsage> fuelUsages, IShip? ship = null)
        {
            if (time < 0)
            {
                throw new ArgumentException(
                    "Damage cannot be negative",
                    nameof(time));
            }

            Time = time;
            Ship = ship;
            FuelUsages = fuelUsages;
            IMarket fuelMarket = new FuelMarket();
            Money = fuelMarket.CalculateCost(FuelUsages);
        }

        public decimal Time { get; }
        public IReadOnlyCollection<IFuelUsage> FuelUsages { get; }
        public decimal Money { get; }

        public IShip? Ship { get; }
    }
}