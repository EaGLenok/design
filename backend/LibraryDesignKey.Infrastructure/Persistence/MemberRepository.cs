using System.Text.Json;
using LibraryDesignKey.Domain.Entities;
using LibraryDesignKey.Shared.Settings;
using Microsoft.Extensions.Options;

namespace LibraryDesignKey.Infrastructure.Persistence;

public class MemberRepositoryJson : IMemberRepository
{
    private readonly string _path;
    private readonly List<Member> _cache;

    public MemberRepositoryJson(IOptions<StorageSettings> options)
    {
        _path = options.Value.MembersFilePath;
        _cache = File.Exists(_path)
            ? JsonSerializer.Deserialize<List<Member>>(File.ReadAllText(_path))!
            : new List<Member>();
    }

    public Task AddAsync(Member member)
    {
        _cache.Add(member);
        return SaveChangesAsync();
    }

    public Task<Member?> GetByIdAsync(string id) => Task.FromResult(_cache.SingleOrDefault(x => x.MemberId == id));

    public Task SaveChangesAsync()
    {
        Directory.CreateDirectory(Path.GetDirectoryName(_path)!);
        File.WriteAllText(_path, JsonSerializer.Serialize(_cache, new JsonSerializerOptions { WriteIndented = true }));
        return Task.CompletedTask;
    }
}