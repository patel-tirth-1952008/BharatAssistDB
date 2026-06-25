namespace BharatAssist.Core.Entities;

public class Service
{
    public int ServiceId { get; set; }

    public int ServiceGroupId { get; set; }

    public string ServiceName { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public decimal GovernmentFee { get; set; }

    public int EstimatedMinutes { get; set; }

    public string Difficulty { get; set; } = "Easy";

    public bool IsActive { get; set; } = true;

    public ServiceGroup ServiceGroup { get; set; } = null!;
}