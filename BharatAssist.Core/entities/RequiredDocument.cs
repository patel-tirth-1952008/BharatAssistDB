namespace BharatAssist.Core.Entities;

public class RequiredDocument
{
    public int RequiredDocumentId { get; set; }

    public int ServiceId { get; set; }

    public string DocumentName { get; set; } = "";

    public bool Mandatory { get; set; }

    public Service Service { get; set; } = null!;
}