using LibraryDesignKey.Shared.DTOs;
using MediatR;

namespace LibraryDesingKey.Application.Queries.Book;

public record GetAllBooksQuery() : IRequest<IEnumerable<BookDto>>;