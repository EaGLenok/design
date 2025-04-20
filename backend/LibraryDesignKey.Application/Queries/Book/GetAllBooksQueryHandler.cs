using AutoMapper;
using LibraryDesignKey.Infrastructure.Persistence;
using LibraryDesignKey.Shared.DTOs;
using MediatR;

namespace LibraryDesingKey.Application.Queries.Book;

public class GetAllBooksQueryHandler(IBookRepository repo, IMapper mapper)
    : IRequestHandler<GetAllBooksQuery, IEnumerable<BookDto>>
{
    public async Task<IEnumerable<BookDto>> Handle(GetAllBooksQuery q, CancellationToken ct)
    {
        var list = await repo.GetAllAsync();
        return mapper.Map<IEnumerable<BookDto>>(list);
    }
}