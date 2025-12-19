using Lab5.Application.Abstractions.Persistence.Repositories;
using Lab5.Application.Abstractions.Queries;
using Lab5.Domain.Operations;

namespace Lab5.Infrastructure.Repositories;

public class OperationHistoryRepository : IOperationsHistoryRepository
{
    private readonly List<BankOperation> _operations = [];

    public void Add(BankOperation bankOperation)
    {
        bankOperation = new BankOperation(
            new OperationId(_operations.Count + 1),
            bankOperation.AccountNumber,
            bankOperation.Date,
            bankOperation.OperationType);

        _operations.Add(bankOperation);
    }

    public IEnumerable<BankOperation> Query(OperationHistoryQuery query)
    {
        return _operations.Where(x => query.BankNumbers.Contains(x.AccountNumber));
    }
}