using Lab5.Application.Contracts.Sessions.Operations;

namespace Lab5.Application.Contracts.Sessions;

public interface ISessionService
{
    CreateAdminSession.Response CreateAdminSession(CreateAdminSession.Request request);

    CreateUserSession.Response CreateUserSession(CreateUserSession.Request request);
}