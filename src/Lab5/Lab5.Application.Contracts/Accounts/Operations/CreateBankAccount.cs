using Lab5.Application.Contracts.Accounts.Models;

namespace Lab5.Application.Contracts.Accounts.Operations;

public static class CreateBankAccount
{
    public readonly record struct Request(Guid Id, int BankNumber, string Password);

    public abstract record Response
    {
        private Response() { }

        public sealed record Success(AccountDto Account) : Response { }

        public sealed record BadRequest(string Error) : Response { }

        public sealed record Unauthorized(string Error) : Response { }
    }
}