namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObject;

public record Mass
{
    public double Value { get; }

    public Mass(double massValue)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(massValue);
        Value = massValue;
    }
}