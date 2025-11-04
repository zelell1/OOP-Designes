namespace Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

public class Damage
{
    public int Value { get; }

    public Damage(int value)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(value);
        Value = value;
    }
}