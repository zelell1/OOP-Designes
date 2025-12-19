using Lab5.Application.Contracts.OperationsHistory;
using Lab5.Application.Contracts.OperationsHistory.Models;
using Lab5.Application.Contracts.OperationsHistory.Operations;
using Lab5.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lab5.Presentation.Controllers;

[ApiController]
[Route("api/history")]
public class OperationHistoryController : ControllerBase
{
    private readonly IOperationHistoryService _historyService;

    public OperationHistoryController(IOperationHistoryService historyService)
    {
        _historyService = historyService;
    }

    [HttpPost]
    public ActionResult<OperationHistoryDto> GetHistory([FromBody] OperationHistoryRequest userRequest)
    {
        var request = new GetOperationHistory.Request(userRequest.Id.Value);
        GetOperationHistory.Response response = _historyService.GetOperationHistory(request);

        return response switch
        {
            GetOperationHistory.Response.Success success => Ok(success.Operations),
            GetOperationHistory.Response.BadRequest badRequest => BadRequest(badRequest.Error),
            GetOperationHistory.Response.Unauthorized unauthorized => Unauthorized(unauthorized.Error),
            _ => throw new UnreachableException(),
        };
    }
}