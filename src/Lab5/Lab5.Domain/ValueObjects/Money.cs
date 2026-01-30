namespace Lab5.Domain.ValueObjects;

public readonly record struct Money
{
    public decimal Value { get; }

    public Money(decimal value)
    {
        Value = value;
    }

    public static Money Zero => new Money(0);
}