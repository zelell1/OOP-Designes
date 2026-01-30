namespace Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

public class TopicTitle
{
    public string Value { get; }

    public TopicTitle(string value)
    {
        ArgumentException.ThrowIfNullOrEmpty(value);
        Value = value;
    }
}