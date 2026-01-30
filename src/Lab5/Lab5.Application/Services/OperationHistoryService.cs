using Lab5.Application.Abstractions.Persistence;
using Lab5.Application.Abstractions.Queries;
using Lab5.Application.Contracts.OperationsHistory;
using Lab5.Application.Contracts.OperationsHistory.Operations;
using Lab5.Application.Mapping;
using Lab5.Domain.Operations;
using Lab5.Domain.Sessions;
using Lab5.Domain.Sessions.SessionEnteties;

namespace Lab5.Application.Services;

public class OperationHistoryService : IOperationHistoryService
{
    private readonly IPersistenceContext _context;

    public OperationHistoryService(IPersistenceContext context)
    {
        _context = context;
    }

    public GetOperationHistory.Response GetOperationHistory(GetOperationHistory.Request request)
    {
        ISession? session = _context.Sessions.Query(
                SessionQuery.Build(x => x.WithId(request.Id)))
                .FirstOrDefault();

        if (session is not UserSession userSession)
        {
            return new GetOperationHistory.Response.Unauthorized("You dont have permission");
        }

        IEnumerable<BankOperation> history = _context
            .Operations
            .Query(OperationHistoryQuery.Build(builder => builder.WithBankNumber(userSession.BankNumber)));

        return new GetOperationHistory.Response.Success(history.MapToDto());
    }
}