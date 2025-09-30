namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObject;

public record PassengerFlow
{
    public int Value { get; }

    public PassengerFlow(int valueFlow)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(valueFlow);
        Value = valueFlow;
    }
}