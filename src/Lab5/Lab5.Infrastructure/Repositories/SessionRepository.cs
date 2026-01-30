using Lab5.Application.Abstractions.Persistence.Repositories;
using Lab5.Application.Abstractions.Queries;
using Lab5.Domain.Sessions;

namespace Lab5.Infrastructure.Repositories;

public class SessionRepository : ISessionsRepository
{
    private readonly Dictionary<Guid, ISession> _sessions = [];

    public void Add(Guid id, ISession session)
    {
        _sessions.Add(id, session);
    }

    public bool TryDeleteSession(Guid id)
    {
        return _sessions.Remove(id);
    }

    public IEnumerable<ISession> Query(SessionQuery query)
    {
        return _sessions.Values
            .Where(x => query.Id.Contains(x.Id));
    }
}