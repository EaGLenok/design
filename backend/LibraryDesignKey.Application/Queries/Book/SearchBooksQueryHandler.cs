using AutoMapper;
using LibraryDesignKey.Infrastructure.Persistence;
using LibraryDesignKey.Shared.DTOs;
using MediatR;

namespace LibraryDesingKey.Application.Queries.Book;

public class SearchBooksQueryHandler(IBookRepository repo, IMapper mapper)
    : IRequestHandler<SearchBooksQuery, IEnumerable<BookDto>>
{
    public async Task<IEnumerable<BookDto>> Handle(SearchBooksQuery q, CancellationToken ct)
    {
        var list = await repo.GetAllAsync();
        var filtered = list.Where(b =>
            b.Title.Contains(q.Query, StringComparison.OrdinalIgnoreCase) ||
            b.Author.Contains(q.Query, StringComparison.OrdinalIgnoreCase));
        return mapper.Map<IEnumerable<BookDto>>(filtered);
    }
}