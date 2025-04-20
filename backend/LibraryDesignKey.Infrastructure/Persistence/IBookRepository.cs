using LibraryDesignKey.Domain.Entities;

namespace LibraryDesignKey.Infrastructure.Persistence;

public interface IBookRepository
{
    Task<IEnumerable<Book>> GetAllAsync();
    Task<Book?> GetByISBNAsync(string isbn);
    Task AddAsync(Book book);
    Task UpdateAsync(Book book);
    Task SaveChangesAsync();
}