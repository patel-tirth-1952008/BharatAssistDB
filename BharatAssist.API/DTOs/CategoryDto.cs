namespace BharatAssist.API.DTOs;

public class CategoryDto
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = string.Empty;

    public string? Icon { get; set; }
}