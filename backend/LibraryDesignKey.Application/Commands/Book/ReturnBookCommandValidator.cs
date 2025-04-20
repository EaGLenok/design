using FluentValidation;

namespace LibraryDesingKey.Application.Commands.Book;

public class ReturnBookCommandValidator : AbstractValidator<ReturnBookCommand>
{
    public ReturnBookCommandValidator()
    {
        RuleFor(x => x.MemberId).NotEmpty();
        RuleFor(x => x.ISBN).NotEmpty();
    }
}