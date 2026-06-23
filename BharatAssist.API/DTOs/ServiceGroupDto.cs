namespace BharatAssist.API.DTOs;

public class ServiceGroupDto
{
    public int ServiceGroupId { get; set; }

    public int CategoryId { get; set; }

    public string GroupName { get; set; } = string.Empty;

    public string? Icon { get; set; }
}
