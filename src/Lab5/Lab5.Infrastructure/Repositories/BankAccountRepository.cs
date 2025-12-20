using Lab5.Application.Abstractions.Persistence.Repositories;
using Lab5.Application.Abstractions.Queries;
using Lab5.Domain.Accounts;

namespace Lab5.Infrastructure.Repositories;

public class BankAccountRepository : IBankAccountRepository
{
    private readonly Dictionary<BankAccountId, BankAccount> _bankAccounts = [];

    public void Add(BankAccount bankAccount)
    {
        var id = new BankAccountId(_bankAccounts.Count + 1);

        var account = new BankAccount(
            id,
            bankAccount.BankNumber,
            bankAccount.Password);

        _bankAccounts.Add(id, account);
    }

    public void Update(BankAccount bankAccount)
    {
        _bankAccounts[bankAccount.Id] = bankAccount;
    }

    public IEnumerable<BankAccount> Query(BankAccountQuery query)
    {
        return _bankAccounts.Values
            .Where(x => query.BankNumbers.Contains(x.BankNumber));
    }
}