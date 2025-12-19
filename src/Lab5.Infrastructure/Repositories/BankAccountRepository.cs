using Lab5.Application.Abstractions.Persistence.Repositories;
using Lab5.Domain.Accounts;
using Lab5.Domain.ValueObjects;

namespace Lab5.Infrastructure.Repositories;

public class BankAccountRepository : IBankAccountRepository
{
    private readonly Dictionary<BankNumber, BankAccount> _bankAccounts = [];

    public void Add(BankAccount bankAccount)
    {
        _bankAccounts.Add(bankAccount.BankNumber, bankAccount);
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