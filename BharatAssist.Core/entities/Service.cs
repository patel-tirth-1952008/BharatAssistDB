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

    
    [Column("Fee")]
    public decimal GovernmentFee { get; set; }

    [Column("StepNumber")]
    public string StepNumber { get; set; } = "";

    [Column("AndroidGuide")]
    public string AndroidGuide { get; set; } = "";

    [Column("Screenshot")]
    public string Screenshot { get; set; } = "";
    
    [Column("WarningText")]
    public string WarningText { get; set; } = "";
    
    [Column("Tip")]
    public string Tip { get; set; } = "";
    

    public ServiceGroup ServiceGroup { get; set; } = null!;

    public ICollection<Faq> Faqs { get; set; } = new List<Faq>();

    public ICollection<RequiredDocument> RequiredDocuments { get; set; } = new List<RequiredDocument>();

    public ICollection<CommunityTip> CommunityTips { get; set; } = new List<CommunityTip>();
    [Column("NOTICE")]
    public string? NOTICE { get; set; }
    [Column("DirectModuleLink")]
    public string DirectModuleLink { get; set; } = "";
}