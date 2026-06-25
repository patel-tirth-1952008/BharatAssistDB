namespace BharatAssist.Core.Entities;

public class CommunityTip
{
    public int CommunityTipId { get; set; }

    public int ServiceId { get; set; }

    public string UserName { get; set; } = "";

    public string Tip { get; set; } = "";

    public Service Service { get; set; } = null!;
}
