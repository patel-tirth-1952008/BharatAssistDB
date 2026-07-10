namespace BharatAssist.API.DTOs;
using Microsoft.AspNetCore.Http;
public class UserFeedbackDto
{
    public string  ServiceName{ get; set; } = "";

    public string  Issue{ get; set; } = "";

    public IFormFile? Issueimage{get ; set;}

    public IFormFile? Issuevideo{get;set;}
}