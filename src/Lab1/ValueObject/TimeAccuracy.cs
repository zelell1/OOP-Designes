namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObject;

public record TimeAccuracy
{
    public double Value { get; }

    public TimeAccuracy(double timeAccuracyValue)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(timeAccuracyValue);
        Value = timeAccuracyValue;
    }
}