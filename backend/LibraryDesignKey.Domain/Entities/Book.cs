namespace LibraryDesignKey.Domain.Entities;

public class Book
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string Author { get; set; } = null!;
    public string ISBN { get; set; } = null!;
    public string Genre { get; set; } = null!;
    public int TotalCopies { get; set; }
    public string? Description { get; set; }
    public List<BorrowRecord> BorrowRecords { get; } = new();
    public int AvailableCopies => TotalCopies - BorrowRecords.Count;
}