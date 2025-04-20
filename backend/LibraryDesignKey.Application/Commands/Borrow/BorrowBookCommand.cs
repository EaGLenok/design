using MediatR;

namespace LibraryDesingKey.Application.Commands.Borrow;

public record BorrowBookCommand(string MemberId, string ISBN) : IRequest<Unit>;