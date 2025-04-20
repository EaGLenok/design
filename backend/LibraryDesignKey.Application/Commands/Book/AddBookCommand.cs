using MediatR;

namespace LibraryDesingKey.Application.Commands.Book;

public record AddBookCommand(
    string Title,
    string Author,
    string ISBN,
    string Genre,
    int TotalCopies,
    string? Description) : IRequest<Guid>;