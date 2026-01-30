namespace Lab5.Domain.Accounts;

public readonly record struct BankAccountId
{
    public int Value { get; }

    public BankAccountId(int value)
    {
        Value = value;
    }

    public static readonly BankAccountId Default = new(default);
}