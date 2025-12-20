using Lab5.Application.Abstractions.Persistence;
using Lab5.Application.Abstractions.Queries;
using Lab5.Application.Contracts.Sessions;
using Lab5.Application.Contracts.Sessions.Operations;
using Lab5.Application.Mapping;
using Lab5.Domain.Accounts;
using Lab5.Domain.Sessions.SessionEnteties;

using Lab5.Domain.ValueObjects;

namespace Lab5.Application.Services;

public class SessionService : ISessionService
{
    private readonly IPersistenceContext _context;

    public SessionService(IPersistenceContext context)
    {
        _context = context;
    }

    public CreateAdminSession.Response CreateAdminSession(CreateAdminSession.Request request)
    {
        if (_context.Password.Password != request.Password)
        {
            return new CreateAdminSession.Response.Unauthorized("Wrong admin password");
        }

        var sessionId = Guid.NewGuid();

        var session = new AdminSession(sessionId);

        _context.Sessions.Add(sessionId, session);

        return new CreateAdminSession.Response.Success(session.MapToDto());
    }

    public CreateUserSession.Response CreateUserSession(CreateUserSession.Request request)
    {
        BankAccount? account = _context.BankAccounts.Query(
                BankAccountQuery.Build(x => x.WithBankNumber(new BankNumber(request.BankNumber))))
            .FirstOrDefault();

        if (account is null)
        {
            return new CreateUserSession.Response.BadRequest("Account not found");
        }

        if (account.Password.Value != request.Password)
        {
            return new CreateUserSession.Response.Unauthorized("Wrong password");
        }

        var sessionId = Guid.NewGuid();

        var session = new UserSession(sessionId, account.BankNumber);

        _context.Sessions.Add(sessionId, session);

        return new CreateUserSession.Response.Success(session.MapToDto());
    }
}