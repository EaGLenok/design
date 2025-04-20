using LibraryDesingKey.Application.Commands.Member;
using LibraryDesingKey.Application.Queries.Member;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryDesignKey.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MembersController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Register(RegisterMemberCommand cmd) =>
        Created(string.Empty, await mediator.Send(cmd));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDetails(string id) => Ok(await mediator.Send(new GetMemberDetailsQuery(id)));
}