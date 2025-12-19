using Lab5.Application.Contracts.Sessions.Models;
using Lab5.Domain.Sessions;

namespace Lab5.Application.Mapping;

public static class SessionMappingExtension
{
    public static SessionDto MapToDto(this ISession userSession)
        => new SessionDto(userSession.Id);
}