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
    

    
    private readonly IWebHostEnvironment _environment;

    public FeedbackController(
    BharatAssistDbContext context,
    IWebHostEnvironment environment)
{
    _context = context;
    _environment = environment;
}

    [HttpPost("Create")]
public async Task<IActionResult> Create([FromForm] UserFeedbackDto dto)
{
    Console.WriteLine($"WebRootPath: {_environment.WebRootPath}");
Console.WriteLine($"ContentRootPath: {_environment.ContentRootPath}");
    try
    {

        string? imagePath = null;
        if(dto.Issueimage != null)
{
    var fileName = Guid.NewGuid().ToString() +
            Path.GetExtension(dto.Issueimage.FileName);

    
    var folderPath = Path.Combine(
    _environment.WebRootPath,
    "uploads",
    "images"
);
    if (!Directory.Exists(folderPath))
{
    Directory.CreateDirectory(folderPath);
}
    var fullPath = Path.Combine(folderPath, fileName);

    using (var stream = new FileStream(fullPath, FileMode.Create))
{
    await dto.Issueimage.CopyToAsync(stream);
}
    imagePath = Path.Combine("uploads", "images", fileName)
                .Replace("\\", "/");
}
        string? videoPath = null;
        if(dto.Issuevideo != null)
{
    var fileName = Guid.NewGuid().ToString() +
               Path.GetExtension(dto.Issuevideo.FileName);

var folderPath = Path.Combine(
    _environment.WebRootPath,
    "uploads",
    "videos"
);

if (!Directory.Exists(folderPath))
{
    Directory.CreateDirectory(folderPath);
}

var fullPath = Path.Combine(folderPath, fileName);

using (var stream = new FileStream(fullPath, FileMode.Create))
{
    await dto.Issuevideo.CopyToAsync(stream);
}

videoPath = Path.Combine("uploads", "videos", fileName)
                .Replace("\\", "/");
    
}
        var feedback = new UserFeedback
        {
            ServiceName = dto.ServiceName,
            Issue = dto.Issue,
            ProblemStatus = "Pending",
            CreatedAt = DateTime.Now,
            Issueimage = imagePath,
            Issuevideo = videoPath,
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
    catch (Exception ex)
    {
        return StatusCode(500, new
        {
            error = ex.Message,
            inner = ex.InnerException?.Message,
            stack = ex.StackTrace
        });
    }
}
}