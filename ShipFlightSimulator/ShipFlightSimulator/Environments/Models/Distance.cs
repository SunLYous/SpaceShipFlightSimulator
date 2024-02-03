using ShipFlightSimulator.Exceptions;

namespace ShipFlightSimulator.Environments.Models;

public class Distance
{
    private const decimal MinimumDistance = 0;

    public Distance(decimal value)
    {
        if (value < MinimumDistance)
        {
            throw new InvalidValueException("the value must be greater than 0");
        }

        Value = value;
    }

    public decimal Value { get; private set; }
}