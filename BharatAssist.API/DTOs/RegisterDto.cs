namespace BharatAssist.API.DTOs;

public class RegisterDto
{
    public string FullName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string? MobileNumber { get; set; }
}