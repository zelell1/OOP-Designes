namespace Lab5.Domain.Operations;

public readonly record struct OperationId
{
    public int Value { get; }

    public OperationId(int value)
    {
        Value = value;
    }

    public static readonly OperationId Default = new(default);
}