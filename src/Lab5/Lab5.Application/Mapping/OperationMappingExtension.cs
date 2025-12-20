using Lab5.Application.Contracts.OperationsHistory.Models;
using Lab5.Domain.Operations;
using Lab5.Domain.Operations.OperationTypes;

namespace Lab5.Application.Mapping;

public static class OperationMappingExtension
{
    public static OperationDto MapToDto(this BankOperation operation)
    {
        decimal amount = 0m;

        if (operation.OperationType is IOperationWithAmount op)
        {
            amount = op.Amount;
        }

        return new OperationDto(operation.Date, amount, operation.OperationType.GetType().Name);
    }
}