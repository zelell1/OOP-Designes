namespace Lab5.Domain.Sessions.SessionEnteties;

public class AdminSession : ISession
{
    public Guid Id { get; }

    public AdminSession(Guid id)
    {
        Id = id;
    }
}