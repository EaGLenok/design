using LibraryDesignKey.Shared.DTOs;
using MediatR;

namespace LibraryDesingKey.Application.Queries.Book;

public record SearchBooksQuery(string Query) : IRequest<IEnumerable<BookDto>>;