using Lab5.Application.Abstractions.Queries;
using Lab5.Domain.Accounts;

namespace Lab5.Application.Abstractions.Persistence.Repositories;

public interface IBankAccountRepository
{
    void Add(BankAccount bankAccount);

    void Update(BankAccount bankAccount);

    IEnumerable<BankAccount> Query(BankAccountQuery query);
}