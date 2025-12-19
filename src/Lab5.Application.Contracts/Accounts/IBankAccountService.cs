using Lab5.Application.Contracts.Accounts.Operations;

namespace Lab5.Application.Contracts.Accounts;

public interface IBankAccountService
{
    CreateBankAccount.Response CreateBankAccount(CreateBankAccount.Request request);

    GetBalance.Response GetBalance(GetBalance.Request request);

    WithdrawMoney.Response WithdrawMoney(WithdrawMoney.Request request);

    TopUpMoney.Response TopUpMoney(TopUpMoney.Request request);
}