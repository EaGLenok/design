using AutoMapper;
using LibraryDesignKey.Infrastructure.Persistence;
using LibraryDesignKey.Shared.DTOs;
using MediatR;

namespace LibraryDesingKey.Application.Queries.Member;

public class GetMemberDetailsQueryHandler(IMemberRepository repo, IMapper mapper)
    : IRequestHandler<GetMemberDetailsQuery, MemberDetailsDto>
{
    public async Task<MemberDetailsDto> Handle(GetMemberDetailsQuery q, CancellationToken ct)
    {
        var member = await repo.GetByIdAsync(q.MemberId)
                     ?? throw new KeyNotFoundException($"Member with ID '{q.MemberId}' not found.");

        return mapper.Map<MemberDetailsDto>(member);
    }
}