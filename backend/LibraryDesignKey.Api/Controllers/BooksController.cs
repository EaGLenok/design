using LibraryDesingKey.Application.Commands.Book;
using LibraryDesingKey.Application.Queries.Book;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryDesignKey.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Add(AddBookCommand cmd) => Created(string.Empty, await mediator.Send(cmd));

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await mediator.Send(new GetAllBooksQuery()));

    [HttpGet("search")]
    public async Task<IActionResult> Search([FromQuery] string q) => Ok(await mediator.Send(new SearchBooksQuery(q)));
}