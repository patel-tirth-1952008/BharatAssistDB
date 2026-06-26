namespace BharatAssist.API.DTOs;

public class CommunityTipDto
{
    public int CommunityTipId { get; set; }

    public string Problem { get; set; } = "";

    public string Solution { get; set; } = "";

    public int Votes { get; set; }
}