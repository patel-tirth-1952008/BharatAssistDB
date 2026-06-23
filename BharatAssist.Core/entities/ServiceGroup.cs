namespace BharatAssist.Core.Entities;

public class ServiceGroup
{
    public int ServiceGroupId { get; set; }

    public int CategoryId { get; set; }

    public string GroupName { get; set; } = string.Empty;

    public string? Description { get; set; }

    public string? Icon { get; set; }

    public int DisplayOrder { get; set; }

    public bool IsActive { get; set; }

    // Navigation Property
    public Category? Category { get; set; }
}