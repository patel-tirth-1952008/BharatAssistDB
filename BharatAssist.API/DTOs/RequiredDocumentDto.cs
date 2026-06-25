namespace BharatAssist.API.DTOs;

public class RequiredDocumentDto
{
    public int RequiredDocumentId { get; set; }

    public string DocumentName { get; set; } = "";

    public bool Mandatory { get; set; }
}