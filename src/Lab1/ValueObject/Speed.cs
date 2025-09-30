namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObject;

public record Speed
{
    public double Value { get; }

    public Speed(double speedValue)
    {
        Value = speedValue;
    }

    public static Speed Zero()
    {
        return new Speed(0);
    }
}
