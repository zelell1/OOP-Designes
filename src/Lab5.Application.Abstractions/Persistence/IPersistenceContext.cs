using Lab5.Application.Abstractions.Persistence.Repositories;

namespace Lab5.Application.Abstractions.Persistence;

public interface IPersistenceContext
{
    IAdminPasswordRepository Password { get; }

    IBankAccountRepository BankAccounts { get; }

    IOperationsHistoryRepository Operations { get; }

    ISessionsRepository Sessions { get; }
}