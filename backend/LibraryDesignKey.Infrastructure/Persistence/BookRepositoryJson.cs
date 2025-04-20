using System.Text.Json;
using LibraryDesignKey.Domain.Entities;
using LibraryDesignKey.Shared.Settings;
using Microsoft.Extensions.Options;

namespace LibraryDesignKey.Infrastructure.Persistence;

public class BookRepositoryJson : IBookRepository
{
    private readonly string _path;
    private readonly List<Book> _cache;

    public BookRepositoryJson(IOptions<StorageSettings> options)
    {
        _path = options.Value.BooksFilePath;
        _cache = File.Exists(_path)
            ? JsonSerializer.Deserialize<List<Book>>(File.ReadAllText(_path))!
            : new List<Book>();
    }

    public Task<IEnumerable<Book>> GetAllAsync() => Task.FromResult(_cache.AsEnumerable());
    public Task<Book?> GetByISBNAsync(string isbn) => Task.FromResult(_cache.SingleOrDefault(x => x.ISBN == isbn));

    public Task AddAsync(Book book)
    {
        _cache.Add(book);
        return SaveChangesAsync();
    }

    public Task UpdateAsync(Book book)
    {
        var idx = _cache.FindIndex(b => b.ISBN == book.ISBN);
        if (idx >= 0) _cache[idx] = book;
        return SaveChangesAsync();
    }

    public Task SaveChangesAsync()
    {
        Directory.CreateDirectory(Path.GetDirectoryName(_path)!);
        File.WriteAllText(_path, JsonSerializer.Serialize(_cache, new JsonSerializerOptions { WriteIndented = true }));
        return Task.CompletedTask;
    }
}