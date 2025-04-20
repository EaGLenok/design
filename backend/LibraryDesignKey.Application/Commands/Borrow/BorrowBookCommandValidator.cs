using FluentValidation;

namespace LibraryDesingKey.Application.Commands.Borrow;

public class BorrowBookCommandValidator : AbstractValidator<BorrowBookCommand>
{
    public BorrowBookCommandValidator()
    {
        RuleFor(x => x.MemberId).NotEmpty();
        RuleFor(x => x.ISBN).NotEmpty();
    }
}