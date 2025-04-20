namespace LibraryDesignKey.Shared.DTOs;

public class MemberDetailsDto
{
    public string MemberId { get; set; }
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? PhoneNumber { get; set; }
    public IEnumerable<BorrowRecordDto> CurrentBorrows { get; set; } = null!;
}