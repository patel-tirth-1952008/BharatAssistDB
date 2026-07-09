namespace BharatAssist.Core.Entities;
using System.ComponentModel.DataAnnotations;

public class UserFeedback
{

    [Key]
    public int FeedbackId { get; set; }
    public string ServiceName { get; set; } = "";

    public string Issue { get; set; } = "";

    public string ProblemStatus { get; set; } = "Pending";

    public string? Adminreply { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public string? Issueimage {get;set;}

    public string? Issuevideo{get;set;}
}