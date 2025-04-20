using LibraryDesignKey.Domain.Entities;

namespace LibraryDesignKey.Infrastructure.Persistence;

public interface IMemberRepository
{
    Task AddAsync(Member member);
    Task<Member?> GetByIdAsync(string id);
    Task SaveChangesAsync();
}