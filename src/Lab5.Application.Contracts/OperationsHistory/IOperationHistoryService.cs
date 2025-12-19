using Lab5.Application.Contracts.OperationsHistory.Operations;

namespace Lab5.Application.Contracts.OperationsHistory;

public interface IOperationHistoryService
{
    GetOperationHistory.Response GetOperationHistory(GetOperationHistory.Request request);
}