using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Contracts.Accounts.Models;
using Lab5.Application.Contracts.Accounts.Operations;
using Lab5.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lab5.Presentation.Controllers;

[ApiController]
[Route("/api/bank/accounts")]
public class BankAccountController : ControllerBase
{
    private readonly IBankAccountService _bankAccountService;

    public BankAccountController(IBankAccountService bankAccountService)
    {
        _bankAccountService = bankAccountService;
    }

    [HttpPost("balance")]
    public ActionResult<AccountDto> GetBalance([FromBody] GetBalanceRequest userRequest)
    {
        var request = new GetBalance.Request(userRequest.Id.Value);
        GetBalance.Response response = _bankAccountService.GetBalance(request);

        return response switch
        {
            GetBalance.Response.Success success => Ok(success.Account),
            GetBalance.Response.BadRequest badRequest => BadRequest(badRequest.Error),
            GetBalance.Response.Unauthorized unauthorized => Unauthorized(unauthorized.Error),
            _ => throw new UnreachableException(),
        };
    }

    [HttpPost("withdraw")]
    public ActionResult<AccountDto> Withdraw([FromBody] BalanceChangeRequest userRequest)
    {
        var request = new WithdrawMoney.Request(userRequest.Id.Value, userRequest.Amount.Value);
        WithdrawMoney.Response response = _bankAccountService.WithdrawMoney(request);

        return response switch
        {
            WithdrawMoney.Response.Success success => Ok(success.Account),
            WithdrawMoney.Response.BadRequest badRequest => BadRequest(badRequest.Error),
            WithdrawMoney.Response.Unauthorized unauthorized => Unauthorized(unauthorized.Error),
            _ => throw new UnreachableException(),
        };
    }

    [HttpPost("deposit")]
    public ActionResult<AccountDto> Deposit([FromBody] BalanceChangeRequest userRequest)
    {
        var request = new TopUpMoney.Request(userRequest.Id.Value, userRequest.Amount.Value);
        TopUpMoney.Response response = _bankAccountService.TopUpMoney(request);

        return response switch
        {
            TopUpMoney.Response.Success success => Ok(success.Account),
            TopUpMoney.Response.BadRequest badRequest => BadRequest(badRequest.Error),
            TopUpMoney.Response.Unauthorized unauthorized => Unauthorized(unauthorized.Error),
            _ => throw new UnreachableException(),
        };
    }

    [HttpPost]
    public ActionResult<AccountDto> CreateAccount([FromBody] CreateBankAccountRequest adminRequest)
    {
        var request = new CreateBankAccount.Request(
            adminRequest.Id.Value,
            adminRequest.BankNumber.Value,
            adminRequest.Password);

        CreateBankAccount.Response response = _bankAccountService.CreateBankAccount(request);

        return response switch
        {
            CreateBankAccount.Response.Success success => Ok(success.Account),
            CreateBankAccount.Response.BadRequest badRequest => BadRequest(badRequest.Error),
            CreateBankAccount.Response.Unauthorized unauthorized => Unauthorized(unauthorized.Error),
            _ => throw new UnreachableException(),
        };
    }
}