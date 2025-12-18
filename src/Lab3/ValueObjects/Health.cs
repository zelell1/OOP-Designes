namespace Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

public readonly record struct Health
{
    public int Value { get; }

    public Health(int value)
    {
        Value = value;
    }
}