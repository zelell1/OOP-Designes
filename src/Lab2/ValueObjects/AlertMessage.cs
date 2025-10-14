namespace Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

public class AlertMessage
{
    public IReadOnlyCollection<string> Values { get; }

    public AlertMessage(IReadOnlyCollection<string> values)
    {
        Values = values;
    }
}