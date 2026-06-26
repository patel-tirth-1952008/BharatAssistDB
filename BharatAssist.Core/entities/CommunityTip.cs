using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BharatAssist.Core.Entities;

public class CommunityTip
{
    [Key]
    [Column("TipId")]
    public int CommunityTipId { get; set; }

    public int ServiceId { get; set; }

    public int? StepId { get; set; }

    public int UserId { get; set; }

    public string Problem { get; set; } = "";

    public string Solution { get; set; } = "";

    public string? Screenshot { get; set; }

    public string? Device { get; set; }

    public string? Browser { get; set; }

    public int Votes { get; set; }

    public string Status { get; set; } = "";

    public Service Service { get; set; } = null!;
}