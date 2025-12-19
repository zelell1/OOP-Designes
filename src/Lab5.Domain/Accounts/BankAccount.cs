using Lab5.Domain.Accounts.ResultType;
using Lab5.Domain.ValueObjects;

namespace Lab5.Domain.Accounts;

public sealed class BankAccount
{
    public Money Money { get; private set; } = Money.Zero;

    public BankNumber BankNumber { get; }

    public Password Password { get; }

    public BankAccount(BankNumber number, Password password)
    {
        BankNumber = number;
        Password = password;
    }

    public void TopUp(Money amount)
    {
        Money = new Money(amount.Value + Money.Value);
    }

    public WithdrawResult TryToWithdraw(Money amount)
    {
        if (amount.Value > Money.Value)
        {
            return new WithdrawResult.Failure();
        }

        Money = new Money(Money.Value - amount.Value);
        return new WithdrawResult.Success();
    }
}