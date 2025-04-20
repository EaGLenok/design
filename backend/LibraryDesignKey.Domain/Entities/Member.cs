namespace LibraryDesignKey.Domain.Entities;

public class Member
{
    public string MemberId { get; set; }
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? PhoneNumber { get; set; }
    public List<BorrowRecord> CurrentBorrows { get; } = new();
}