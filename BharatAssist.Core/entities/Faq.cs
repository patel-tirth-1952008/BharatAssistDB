namespace BharatAssist.Core.Entities;

public class Faq
{
    public int FaqId { get; set; }

    public int ServiceId { get; set; }

    public string Question { get; set; } = "";

    public string Answer { get; set; } = "";

    public Service Service { get; set; } = null!;
}