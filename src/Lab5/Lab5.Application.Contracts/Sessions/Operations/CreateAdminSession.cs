using Lab5.Application.Contracts.Sessions.Models;

namespace Lab5.Application.Contracts.Sessions.Operations;

public static class CreateAdminSession
{
    public readonly record struct Request(string Password);

    public abstract record Response
    {
        private Response() { }

        public sealed record Success(SessionDto Session) : Response { }

        public sealed record BadRequest(string Error) : Response { }

        public sealed record Unauthorized(string Error) : Response { }
    }
}