namespace Lab5.Domain.ValueObjects;

public readonly record struct Password
{
    public string Value { get; }

    public Password(string password)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(password);
        Value = password;
    }
}