namespace BharatAssist.Core.Entities;

public class ServiceGroup
{
    public int ServiceGroupId { get; set; }

    public int CategoryId { get; set; }

    public string GroupName { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public Category Category { get; set; } = null!;

    public ICollection<Service> Services { get; set; } = new List<Service>();
}