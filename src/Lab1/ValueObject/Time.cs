namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObject;

public record Time
{
    public double Value { get; }

    public Time(double timeValue)
    {
        Value = timeValue;
    }

    public static Time Zero()
    {
       return new Time(0);
    }
}