namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObject;

public record Force
{
    public double Value { get; }

    public Force(double forceValue)
    {
        Value = forceValue;
    }

    public static Force Zero()
    {
        return new Force(0);
    }
}