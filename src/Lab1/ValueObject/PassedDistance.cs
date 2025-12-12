namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObject;

public record PassedDistance
{
    public double Value { get; }

    public PassedDistance(double passedDistance)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(passedDistance);
        Value = passedDistance;
    }

    public static PassedDistance Zero()
    {
        return new PassedDistance(0);
    }
}