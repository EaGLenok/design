namespace LibraryDesignKey.Domain.Entities;

public class BorrowRecord
{
    public string MemberId { get; set; }
    public string ISBN { get; set; } = null!;
    public DateTime BorrowDate { get; set; }
}