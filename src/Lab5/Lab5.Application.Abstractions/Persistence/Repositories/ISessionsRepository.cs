using Lab5.Domain.Sessions;

namespace Lab5.Application.Abstractions.Persistence.Repositories;

public interface ISessionsRepository
{
    void Add(Guid id, ISession session);

    ISession? GetSession(Guid id);
}