namespace Lab5.Application.Contracts.OperationsHistory.Models;

public sealed record OperationDto(DateTime Date, decimal Amount, string OperationType);