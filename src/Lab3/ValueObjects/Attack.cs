namespace Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

public readonly record struct Attack
{
    public int Value { get; }

    public Attack(int value)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(value);
        Value = value;
    }
}