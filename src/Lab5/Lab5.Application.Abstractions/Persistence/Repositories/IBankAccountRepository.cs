using Lab5.Domain.Accounts;
using Lab5.Domain.ValueObjects;

namespace Lab5.Application.Abstractions.Persistence.Repositories;

public interface IBankAccountRepository
{
    void Add(BankAccount bankAccount);

    void Update(BankAccount bankAccount);

    BankAccount? GetBankAccount(BankNumber? bankNumber);
}