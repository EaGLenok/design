using AutoMapper;
using LibraryDesignKey.Infrastructure.Persistence;
using LibraryDesignKey.Shared.Exceptions;
using MediatR;

namespace LibraryDesingKey.Application.Commands.Book;

public class AddBookCommandHandler(IBookRepository repo, IMapper mapper) : IRequestHandler<AddBookCommand, Guid>
{
    public async Task<Guid> Handle(AddBookCommand cmd, CancellationToken ct)
    {
        if (await repo.GetByISBNAsync(cmd.ISBN) != null)
            throw new DuplicateEntityException("ISBN exists");

        var book = mapper.Map<LibraryDesignKey.Domain.Entities.Book>(cmd);
        book.Id = Guid.NewGuid();

        await repo.AddAsync(book);
        return book.Id;
    }
}