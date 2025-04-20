using MediatR;

namespace LibraryDesingKey.Application.Commands.Member;

public record RegisterMemberCommand(
    string MemberId,
    string FullName,
    string Email,
    string? PhoneNumber
) : IRequest<Unit>;