using LibraryDesingKey.Application.Commands.Book;
using LibraryDesingKey.Application.Commands.Borrow;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryDesignKey.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BorrowingController(IMediator mediator) : ControllerBase
{
    [HttpPost("borrow")]
    public async Task<IActionResult> Borrow([FromBody] BorrowBookCommand cmd) =>
        Ok(await mediator.Send(cmd));

    [HttpPost("return")]
    public async Task<IActionResult> Return([FromBody] ReturnBookCommand cmd) =>
        Ok(await mediator.Send(cmd));
}
