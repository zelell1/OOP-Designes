namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObject;

public record Boost
{
    public double Value { get; }

    public Boost(double boostValue)
    {
        Value = boostValue;
    }

    public static Boost Zero()
    {
        return new Boost(0);
    }
}