using MediatR;

namespace LibraryDesingKey.Application.Commands.Book;

public record ReturnBookCommand(string MemberId, string ISBN) : IRequest<Unit>;