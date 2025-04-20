using LibraryDesignKey.Domain.Entities;
using LibraryDesignKey.Infrastructure.Persistence;
using MediatR;

namespace LibraryDesingKey.Application.Commands.Borrow;

public class BorrowBookCommandHandler(IBookRepository bookRepo, IMemberRepository memberRepo)
    : IRequestHandler<BorrowBookCommand, Unit>
{
    public async Task<Unit> Handle(BorrowBookCommand cmd, CancellationToken ct)
    {
        var book = await bookRepo.GetByISBNAsync(cmd.ISBN)
                   ?? throw new KeyNotFoundException();
        if (book.AvailableCopies < 1)
            throw new InvalidOperationException();

        var member = await memberRepo.GetByIdAsync(cmd.MemberId)
                     ?? throw new KeyNotFoundException();

        if (member.CurrentBorrows.Any(br => br.ISBN == cmd.ISBN))
            throw new InvalidOperationException();

        var record = new BorrowRecord
        {
            MemberId = cmd.MemberId,
            ISBN = cmd.ISBN,
            BorrowDate = DateTime.UtcNow
        };

        book.BorrowRecords.Add(record);
        member.CurrentBorrows.Add(record);

        await bookRepo.UpdateAsync(book);
        await memberRepo.SaveChangesAsync();

        return Unit.Value;
    }
}