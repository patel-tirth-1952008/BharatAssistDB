namespace BharatAssist.Core.Entities;

public class Category
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = string.Empty;

    public string Icon { get; set; } = string.Empty;

    public int DisplayOrder { get; set; }

    public bool IsActive { get; set; } = true;

    public ICollection<ServiceGroup> ServiceGroups { get; set; } = new List<ServiceGroup>();
}