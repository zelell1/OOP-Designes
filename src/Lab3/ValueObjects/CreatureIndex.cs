namespace Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

public class CreatureIndex
{
    public int Value { get; }

    public CreatureIndex(int value)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(value);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(value, 6);
        Value = value;
    }
}