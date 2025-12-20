namespace Lab5.Domain.ValueObjects;

public readonly record struct BankNumber
{
    public int Value { get; }

    public BankNumber(int value)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(value);
        Value = value;
    }
}