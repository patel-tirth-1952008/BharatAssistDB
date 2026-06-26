using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BharatAssist.Core.Entities;

public class Faq
{
    [Key]
    [Column("FAQId")]
    public int FaqId { get; set; }

    public int ServiceId { get; set; }

    public string Question { get; set; } = "";

    public string Answer { get; set; } = "";

    public Service Service { get; set; } = null!;
}