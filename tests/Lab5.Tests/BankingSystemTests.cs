using Lab5.Application.Abstractions.Persistence;
using Lab5.Application.Abstractions.Persistence.Repositories;
using Lab5.Application.Contracts.Accounts.Operations;
using Lab5.Application.Services;
using Lab5.Domain.Accounts;
using Lab5.Domain.Operations;
using Lab5.Domain.Sessions.SessionEnteties;
using Lab5.Domain.ValueObjects;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class BankingSystemTests
{
    [Fact]
    public void TopUpMoney_BalanceReplinished_Success()
    {
        // Arrange
        IAdminPasswordRepository adminPasswordRepository = Substitute.For<IAdminPasswordRepository>();
        IBankAccountRepository bankAccountRepository = Substitute.For<IBankAccountRepository>();
        IOperationsHistoryRepository operationsHistoryRepository = Substitute.For<IOperationsHistoryRepository>();
        ISessionsRepository sessionsRepository = Substitute.For<ISessionsRepository>();
        IPersistenceContext persistenceContext = Substitute.For<IPersistenceContext>();

        persistenceContext.Password.Returns(adminPasswordRepository);
        persistenceContext.BankAccounts.Returns(bankAccountRepository);
        persistenceContext.Operations.Returns(operationsHistoryRepository);
        persistenceContext.Sessions.Returns(sessionsRepository);

        var id = Guid.NewGuid();
        var bankNumber = new BankNumber(1231);
        var password = new Password("password");
        var account = new BankAccount(BankAccountId.Default, bankNumber, password);
        var session = new UserSession(id, bankNumber);

        sessionsRepository.GetSession(id).Returns(session);
        bankAccountRepository.GetBankAccount(bankNumber).Returns(account);

        var service = new BankAccountService(persistenceContext);

        // Act
        var request = new TopUpMoney.Request(id, 100m);
        TopUpMoney.Response result = service.TopUpMoney(request);

        // Assert
        Assert.IsType<TopUpMoney.Response.Success>(result);
        Assert.Equal(100m, account.Money.Value);
        bankAccountRepository.Received(1).GetBankAccount(bankNumber);
        operationsHistoryRepository.Received(1).Add(Arg.Any<BankOperation>());
    }

    [Fact]
    public void WithdrawMoney_BalanceWithdraw_Success()
    {
        // Arrange
        IAdminPasswordRepository adminPasswordRepository = Substitute.For<IAdminPasswordRepository>();
        IBankAccountRepository bankAccountRepository = Substitute.For<IBankAccountRepository>();
        IOperationsHistoryRepository operationsHistoryRepository = Substitute.For<IOperationsHistoryRepository>();
        ISessionsRepository sessionsRepository = Substitute.For<ISessionsRepository>();
        IPersistenceContext persistenceContext = Substitute.For<IPersistenceContext>();

        persistenceContext.Password.Returns(adminPasswordRepository);
        persistenceContext.BankAccounts.Returns(bankAccountRepository);
        persistenceContext.Operations.Returns(operationsHistoryRepository);
        persistenceContext.Sessions.Returns(sessionsRepository);

        var id = Guid.NewGuid();
        var bankNumber = new BankNumber(1231);
        var password = new Password("password");
        var account = new BankAccount(BankAccountId.Default, bankNumber, password);
        var session = new UserSession(id, bankNumber);

        sessionsRepository.GetSession(id).Returns(session);
        bankAccountRepository.GetBankAccount(bankNumber).Returns(account);

        var service = new BankAccountService(persistenceContext);

        // Act
        var requestReplinishment = new TopUpMoney.Request(id, 1000m);
        service.TopUpMoney(requestReplinishment);
        var requestWithdraw = new WithdrawMoney.Request(id, 100m);
        WithdrawMoney.Response result = service.WithdrawMoney(requestWithdraw);

        // Assert
        Assert.IsType<WithdrawMoney.Response.Success>(result);
        Assert.Equal(900m, account.Money.Value);
        bankAccountRepository.Received(2).GetBankAccount(bankNumber);
        operationsHistoryRepository.Received(2).Add(Arg.Any<BankOperation>());
    }

    [Fact]
    public void WithdrawMoney_BalanceNotHaveEnoughMoney_Success()
    {
        // Arrange
        IAdminPasswordRepository adminPasswordRepository = Substitute.For<IAdminPasswordRepository>();
        IBankAccountRepository bankAccountRepository = Substitute.For<IBankAccountRepository>();
        IOperationsHistoryRepository operationsHistoryRepository = Substitute.For<IOperationsHistoryRepository>();
        ISessionsRepository sessionsRepository = Substitute.For<ISessionsRepository>();
        IPersistenceContext persistenceContext = Substitute.For<IPersistenceContext>();

        persistenceContext.Password.Returns(adminPasswordRepository);
        persistenceContext.BankAccounts.Returns(bankAccountRepository);
        persistenceContext.Operations.Returns(operationsHistoryRepository);
        persistenceContext.Sessions.Returns(sessionsRepository);

        var id = Guid.NewGuid();
        var bankNumber = new BankNumber(1231);
        var password = new Password("password");
        var account = new BankAccount(BankAccountId.Default, bankNumber, password);
        var session = new UserSession(id, bankNumber);

        sessionsRepository.GetSession(id).Returns(session);
        bankAccountRepository.GetBankAccount(bankNumber).Returns(account);

        var service = new BankAccountService(persistenceContext);

        // Act
        var requestWithdraw = new WithdrawMoney.Request(id, 100m);
        WithdrawMoney.Response result = service.WithdrawMoney(requestWithdraw);

        // Assert
        Assert.IsType<WithdrawMoney.Response.BadRequest>(result);
        Assert.Equal(0m, account.Money.Value);
        bankAccountRepository.Received(1).GetBankAccount(bankNumber);
        operationsHistoryRepository.DidNotReceive();
    }
}