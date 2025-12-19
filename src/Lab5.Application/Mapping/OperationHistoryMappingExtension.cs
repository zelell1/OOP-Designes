using Lab5.Application.Contracts.OperationsHistory.Models;
using Lab5.Domain.Operations;

namespace Lab5.Application.Mapping;

public static class OperationHistoryMappingExtension
{
    public static OperationHistoryDto MapToDto(this IEnumerable<BankOperation> operations)
        => new OperationHistoryDto(operations.Select(x => x.MapToDto()));
}