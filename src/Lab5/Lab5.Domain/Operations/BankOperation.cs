using Lab5.Domain.Operations.OperationTypes;
using Lab5.Domain.ValueObjects;

namespace Lab5.Domain.Operations;

public sealed class BankOperation
{
    public OperationId Id { get; }

    public BankNumber AccountNumber { get; }

    public DateTime Date { get; }

    public OperationType OperationType { get; }

    public BankOperation(
        OperationId id,
        BankNumber accountNumber,
        DateTime date,
        OperationType operationType)
    {
        Id = id;
        AccountNumber = accountNumber;
        Date = date;
        OperationType = operationType;
    }
}