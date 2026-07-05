namespace BharatAssist.API.DTOs;

public class ServiceGuideStepDto
{
    public int StepId { get; set; }

    public int ServiceId { get; set; }

    public int StepNumber { get; set; }

    public string? AndroidGuide { get; set; }

    public string? Screenshot { get; set; }

    public string? WarningText { get; set; }

    public string? Tip { get; set; }
}