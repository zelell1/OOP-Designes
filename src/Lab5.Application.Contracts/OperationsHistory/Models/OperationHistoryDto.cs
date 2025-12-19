namespace Lab5.Application.Contracts.OperationsHistory.Models;

public sealed record OperationHistoryDto(IEnumerable<OperationDto> Operations);