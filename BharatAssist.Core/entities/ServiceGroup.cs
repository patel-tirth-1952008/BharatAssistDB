using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BharatAssist.Core.Entities;

public class ServiceGroup
{
    [Key]
    [Column("GroupId")]
    public int ServiceGroupId { get; set; }

    public string GroupName { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Icon { get; set; } = string.Empty;

    public string BannerImage { get; set; } = string.Empty;

    public int DisplayOrder { get; set; }

    public bool IsActive { get; set; }

    public int CategoryId { get; set; }

    public Category Category { get; set; } = null!;
}