namespace BharatAssist.API.DTOs;

public class ServiceDto
{
    public int ServiceId { get; set; }

    public int ServiceGroupId { get; set; }

    public string ServiceName { get; set; } = "";

    public string Description { get; set; } = "";

    public decimal GovernmentFee { get; set; }

    public int EstimatedMinutes { get; set; }

    public string Difficulty { get; set; } = "";
}