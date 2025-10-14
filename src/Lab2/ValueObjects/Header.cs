namespace Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

public record Header
{
    public string Value { get; }

    public Header(string value)
    {
        ArgumentException.ThrowIfNullOrEmpty(value);
        Value = value;
    }
}