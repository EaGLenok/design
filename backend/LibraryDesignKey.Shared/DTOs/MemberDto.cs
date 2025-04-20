namespace LibraryDesignKey.Shared.DTOs;

public class MemberDto
{
    public string MemberId { get; set; }
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? PhoneNumber { get; set; }
}