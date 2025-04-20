using FluentValidation;

namespace LibraryDesingKey.Application.Commands.Book;

public class AddBookCommandValidator : AbstractValidator<AddBookCommand>
{
    public AddBookCommandValidator()
    {
        RuleFor(x => x.Title).NotEmpty();
        RuleFor(x => x.Author).NotEmpty();
        RuleFor(x => x.ISBN).NotEmpty();
        RuleFor(x => x.TotalCopies).GreaterThan(0);
    }
}