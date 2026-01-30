using Lab5.Domain.ValueObjects;

namespace Lab5.Domain.Sessions.SessionEnteties;

public sealed class UserSession : ISession
{
    public Guid Id { get; }

    public BankNumber BankNumber { get; }

    public UserSession(Guid id, BankNumber number)
    {
        Id = id;
        BankNumber = number;
    }
}