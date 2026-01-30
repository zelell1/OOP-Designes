using Lab5.Application.Contracts.Accounts.Models;
using Lab5.Domain.Accounts;

namespace Lab5.Application.Mapping;

public static class BankAccountMappingExtension
{
    public static AccountDto MapToDto(this BankAccount bankAccount)
        => new AccountDto(bankAccount.BankNumber.Value, bankAccount.Money.Value);
}