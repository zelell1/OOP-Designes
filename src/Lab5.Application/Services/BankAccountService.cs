using Lab5.Application.Abstractions.Persistence;
using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Contracts.Accounts.Operations;
using Lab5.Application.Mapping;
using Lab5.Domain.Accounts;
using Lab5.Domain.Accounts.ResultType;
using Lab5.Domain.Operations;
using Lab5.Domain.Operations.OperationTypes;
using Lab5.Domain.Sessions;
using Lab5.Domain.Sessions.SessionEnteties;
using Lab5.Domain.ValueObjects;

namespace Lab5.Application.Services;

public class BankAccountService : IBankAccountService
{
    private readonly IPersistenceContext _context;

    public BankAccountService(IPersistenceContext context)
    {
        _context = context;
    }

    public CreateBankAccount.Response CreateBankAccount(CreateBankAccount.Request request)
    {
        ISession? session = _context.Sessions.GetSession(request.Id);

        if (session is not AdminSession)
        {
            return new CreateBankAccount.Response.Unauthorized("Permission denied");
        }

        var account = new BankAccount(
            new BankNumber(request.BankNumber),
            new Password(request.Password));

        _context.BankAccounts.Add(account);

        _context.Operations.Add(
            new BankOperation(
                OperationId.Default,
                new BankNumber(request.BankNumber),
                DateTime.Now,
                new OperationType.CreateBankAccount()));

        return new CreateBankAccount.Response.Success(account.MapToDto());
    }

    public GetBalance.Response GetBalance(GetBalance.Request request)
    {
        ISession? session = _context.Sessions.GetSession(request.Id);

        if (session is not UserSession userSession)
        {
            return new GetBalance.Response.Unauthorized("You dont have permission");
        }

        BankAccount? account = _context.BankAccounts.GetBankAccount(userSession.BankNumber);

        if (account is null)
        {
            return new GetBalance.Response.BadRequest("Account not found");
        }

        _context.Operations.Add(
            new BankOperation(
                OperationId.Default,
                account.BankNumber,
                DateTime.Now,
                new OperationType.ViewBalance(account.Money.Value)));

        return new GetBalance.Response.Success(account.MapToDto());
    }

    public WithdrawMoney.Response WithdrawMoney(WithdrawMoney.Request request)
    {
        ISession? session = _context.Sessions.GetSession(request.Id);

        if (session is not UserSession userSession)
        {
            return new WithdrawMoney.Response.Unauthorized("You dont have permission");
        }

        BankAccount? account = _context.BankAccounts.GetBankAccount(userSession.BankNumber);

        if (account is null)
        {
            return new WithdrawMoney.Response.BadRequest("Account not found");
        }

        WithdrawResult result = account.TryToWithdraw(new Money(request.Amount));

        if (result is WithdrawResult.Failure failure)
        {
            return new WithdrawMoney.Response.BadRequest("You dont have enough money");
        }

        _context.Operations.Add(
            new BankOperation(
                OperationId.Default,
                account.BankNumber,
                DateTime.Now,
                new OperationType.Withdraw(request.Amount)));

        return new WithdrawMoney.Response.Success(account.MapToDto());
    }

    public TopUpMoney.Response TopUpMoney(TopUpMoney.Request request)
    {
        ISession? session = _context.Sessions.GetSession(request.Id);

        if (session is not UserSession userSession)
        {
            return new TopUpMoney.Response.Unauthorized("You dont have permission");
        }

        BankAccount? account = _context.BankAccounts.GetBankAccount(userSession.BankNumber);

        if (account is null)
        {
            return new TopUpMoney.Response.BadRequest("Account not found");
        }

        account.TopUp(new Money(request.Amount));

        _context.Operations.Add(
            new BankOperation(
                OperationId.Default,
                account.BankNumber,
                DateTime.Now,
                new OperationType.Replenishment(request.Amount)));

        return new TopUpMoney.Response.Success(account.MapToDto());
    }
}