using Lab5.Application.Contracts.OperationsHistory.Models;

namespace Lab5.Application.Contracts.OperationsHistory.Operations;

public static class GetOperationHistory
{
    public readonly record struct Request(Guid Id);

    public abstract record Response
    {
        private Response() { }

        public sealed record Success(OperationHistoryDto Operations) : Response { }

        public sealed record BadRequest(string Error) : Response { }

        public sealed record Unauthorized(string Error) : Response { }
    }
}