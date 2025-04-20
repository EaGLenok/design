namespace LibraryDesignKey.Shared.DTOs;

public class BorrowRecordDto
{
    public string ISBN { get; set; } = null!;
    public DateTime BorrowDate { get; set; }
}