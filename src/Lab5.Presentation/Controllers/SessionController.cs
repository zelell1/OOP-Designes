using Lab5.Application.Contracts.Sessions;
using Lab5.Application.Contracts.Sessions.Models;
using Lab5.Application.Contracts.Sessions.Operations;
using Lab5.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lab5.Presentation.Controllers;

[ApiController]
[Route("/api/login")]
public class SessionController : ControllerBase
{
    private readonly ISessionService _sessionService;

    public SessionController(ISessionService sessionService)
    {
        _sessionService = sessionService;
    }

    [HttpPost("user")]
    public ActionResult<SessionDto> LoginUser([FromBody] LoginUserRequest userRequest)
    {
        var request = new CreateUserSession.Request(userRequest.BankNumber.Value, userRequest.Password);
        CreateUserSession.Response response = _sessionService.CreateUserSession(request);

        return response switch
        {
            CreateUserSession.Response.Success success => Ok(success.Session),
            CreateUserSession.Response.BadRequest badRequest => BadRequest(badRequest.Error),
            CreateUserSession.Response.Unauthorized unauthorized => Unauthorized(unauthorized.Error),
            _ => throw new UnreachableException(),
        };
    }

    [HttpPost("admin")]
    public ActionResult<SessionDto> LoginAdmin([FromBody] LoginAdminRequest adminRequest)
    {
        var request = new CreateAdminSession.Request(adminRequest.Password);
        CreateAdminSession.Response response = _sessionService.CreateAdminSession(request);

        return response switch
        {
            CreateAdminSession.Response.Success success => Ok(success.Session),
            CreateAdminSession.Response.BadRequest badRequest => BadRequest(badRequest.Error),
            CreateAdminSession.Response.Unauthorized unauthorized => Unauthorized(unauthorized.Error),
            _ => throw new UnreachableException(),
        };
    }
}