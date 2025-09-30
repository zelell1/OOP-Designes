namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObject;

public record PassengerCount
{
    public int Value { get; }

    public PassengerCount(int valuePassengerCount)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(valuePassengerCount);
        Value = valuePassengerCount;
    }
}