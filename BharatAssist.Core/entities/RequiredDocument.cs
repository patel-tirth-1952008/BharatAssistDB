using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BharatAssist.Core.Entities;

public class RequiredDocument
{
    [Key]
    [Column("DocumentId")]
    public int RequiredDocumentId { get; set; }

    public int ServiceId { get; set; }

    public string DocumentName { get; set; } = "";

    public bool Mandatory { get; set; }

    public string? Notes { get; set; }

    public Service Service { get; set; } = null!;
}