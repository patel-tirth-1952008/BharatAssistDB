namespace BharatAssist.API.DTOs;

public class ServiceDto
{
    public int ServiceId { get; set; }

    public int ServiceGroupId { get; set; }

    public string ServiceName { get; set; } = "";

    public decimal GovernmentFee { get; set; }

    public string NOTICE { get; set; } = "";

    public string DirectModuleLink { get; set; } = "";
}