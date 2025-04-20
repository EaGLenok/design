using LibraryDesignKey.Shared.DTOs;
using MediatR;

namespace LibraryDesingKey.Application.Queries.Member;

public record GetMemberDetailsQuery(string MemberId) : IRequest<MemberDetailsDto>;