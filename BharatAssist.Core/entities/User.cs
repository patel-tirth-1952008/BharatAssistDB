namespace BharatAssist.Core.Entities;

public class User
{
    public int UserId { get; set; }

    public string FullName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public string? MobileNumber { get; set; }

    public bool IsVerified { get; set; }

    public DateTime CreatedAt { get; set; }
}