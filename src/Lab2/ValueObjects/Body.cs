namespace Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

public class Body
{
    public string Value { get; }

    public Body(string value)
    {
        ArgumentException.ThrowIfNullOrEmpty(value);
        Value = value;
    }
}