namespace Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

public class Attack
{
    public int Value { get; }

    public Attack(int value)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(value);
        Value = value;
    }
}