using Lab5.Application.Abstractions.Queries;
using Lab5.Domain.Operations;

namespace Lab5.Application.Abstractions.Persistence.Repositories;

public interface IOperationsHistoryRepository
{
    void Add(BankOperation bankOperation);

    IEnumerable<BankOperation> Query(OperationHistoryQuery query);
}