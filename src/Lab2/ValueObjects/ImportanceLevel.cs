namespace Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

public record ImportanceLevel
{
    public int Value { get; }

    public ImportanceLevel(int value)
    {
        if (value is < 1 or > 10)
        {
            throw new ArgumentOutOfRangeException(value.ToString());
        }

        Value = value;
    }
}
