using Lab5.Application.Abstractions.Persistence;
using Lab5.Application.Abstractions.Persistence.Repositories;

namespace Lab5.Infrastructure;

internal class PersistenceContext : IPersistenceContext
{
    public PersistenceContext(
        IAdminPasswordRepository adminPassword,
        IBankAccountRepository bankAccountRepository,
        IOperationsHistoryRepository operationsHistoryRepository,
        ISessionsRepository sessionsRepository)
    {
        Password = adminPassword;
        BankAccounts = bankAccountRepository;
        Operations = operationsHistoryRepository;
        Sessions = sessionsRepository;
    }

    public IAdminPasswordRepository Password { get; }

    public IBankAccountRepository BankAccounts { get; }

    public IOperationsHistoryRepository Operations { get; }

    public ISessionsRepository Sessions { get; }
}