using LibraryDesignKey.Infrastructure.Persistence;
using MediatR;

namespace LibraryDesingKey.Application.Commands.Book;

public class ReturnBookCommandHandler(IBookRepository bookRepo, IMemberRepository memberRepo)
    : IRequestHandler<ReturnBookCommand, Unit>
{
    public async Task<Unit> Handle(ReturnBookCommand cmd, CancellationToken ct)
    {
        var book = await bookRepo.GetByISBNAsync(cmd.ISBN)
                   ?? throw new KeyNotFoundException();
        var member = await memberRepo.GetByIdAsync(cmd.MemberId)
                     ?? throw new KeyNotFoundException();

        var record = member.CurrentBorrows.SingleOrDefault(br => br.ISBN == cmd.ISBN)
                     ?? throw new InvalidOperationException();
        member.CurrentBorrows.Remove(record);

        var bookRec = book.BorrowRecords.Single(br => br.ISBN == cmd.ISBN && br.MemberId == cmd.MemberId);
        book.BorrowRecords.Remove(bookRec);

        await bookRepo.UpdateAsync(book);
        await memberRepo.SaveChangesAsync();

        return Unit.Value;
    }
}