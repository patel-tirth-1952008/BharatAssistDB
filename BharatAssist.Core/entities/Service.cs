using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BharatAssist.Core.Entities;

public class Service
{
    [Key]
    public int ServiceId { get; set; }

    [Column("GroupId")]
    public int ServiceGroupId { get; set; }

    [Column("ServiceName")]
    public string ServiceName { get; set; } = "";

    [Column("ShortDescription")]
    public string Description { get; set; } = "";

    [Column("Fee")]
    public decimal GovernmentFee { get; set; }

    [NotMapped]
    public int EstimatedMinutes { get; set; }

    [NotMapped]
    public string Difficulty { get; set; } = "Easy";

    public bool IsActive { get; set; }

    public ServiceGroup ServiceGroup { get; set; } = null!;

    public ICollection<Faq> Faqs { get; set; } = new List<Faq>();

    public ICollection<RequiredDocument> RequiredDocuments { get; set; } = new List<RequiredDocument>();

    public ICollection<CommunityTip> CommunityTips { get; set; } = new List<CommunityTip>();
}