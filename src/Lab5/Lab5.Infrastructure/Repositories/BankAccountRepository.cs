using Lab5.Application.Abstractions.Persistence.Repositories;
using Lab5.Domain.Accounts;
using Lab5.Domain.ValueObjects;

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

        _bankAccounts.Add(id, bankAccount);
    }

    public void Update(BankAccount bankAccount)
    {
        _bankAccounts[bankAccount.Id] = bankAccount;
    }

    public BankAccount? GetBankAccount(BankNumber? bankNumber)
    {
        if (bankNumber == null)
        {
            return null;
        }

        return _bankAccounts.Values.
            FirstOrDefault(b => b.BankNumber == bankNumber);
    }
}