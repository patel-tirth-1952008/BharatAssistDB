using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BharatAssist.Core.Entities;

public class ServiceGuideStep
{
    [Key]
    public int StepId { get; set; }

    public int ServiceId { get; set; }

    public int StepNumber { get; set; }

    public string? Screenshot { get; set; }

    public string? AndroidGuide { get; set; }

    public string? WarningText { get; set; }

    public string? Tip { get; set; }

    [ForeignKey(nameof(ServiceId))]
    public Service Service { get; set; } = null!;
}