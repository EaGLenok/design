using AutoMapper;
using LibraryDesignKey.Infrastructure.Persistence;
using MediatR;

namespace LibraryDesingKey.Application.Commands.Member;

public class RegisterMemberCommandHandler(IMemberRepository repo, IMapper mapper)
    : IRequestHandler<RegisterMemberCommand, Unit>
{
    public async Task<Unit> Handle(RegisterMemberCommand cmd, CancellationToken ct)
    {
        var member = mapper.Map<LibraryDesignKey.Domain.Entities.Member>(cmd);
        member.MemberId = cmd.MemberId;

        await repo.AddAsync(member);
        await repo.SaveChangesAsync();

        return Unit.Value;
    }
}