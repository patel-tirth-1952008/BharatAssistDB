using BharatAssist.API.DTOs;
using BharatAssist.Core.Entities;
using BharatAssist.Infrastructure.Data;
using BharatAssist.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BharatAssist.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FeedbackController : ControllerBase
{
    private readonly BharatAssistDbContext _context;

    public FeedbackController(BharatAssistDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Create(UserFeedbackDto dto)
    {
        var feedback = new UserFeedback
        {
            ServiceName = dto.ServiceName,
            Issue = dto.Issue,
            ProblemStatus = "Pending",
            CreatedAt = DateTime.Now
        };

        _context.UserFeedback.Add(feedback);

        await _context.SaveChangesAsync();

        return Ok(new ApiResponse<string>
        {
            Success = true,
            Message = "Feedback submitted successfully.",
            Data = ""
        });
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var feedbacks = await _context.UserFeedback
            .OrderByDescending(x => x.CreatedAt)
            .ToListAsync();

        return Ok(new ApiResponse<List<UserFeedback>>
        {
            Success = true,
            Message = "Success",
            Data = feedbacks
        });
    }
}