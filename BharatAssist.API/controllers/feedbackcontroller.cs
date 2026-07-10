using BharatAssist.API.DTOs;
using BharatAssist.Core.Entities;
using BharatAssist.Infrastructure.Data;
using BharatAssist.Shared;
using Microsoft.AspNetCore.Mvc;

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
        try
        {
            string? imagePath = null;
            string? videoPath = null;

            // Get WebRoot (works locally and on Render)
            string webRoot = _environment.WebRootPath;

            if (string.IsNullOrEmpty(webRoot))
            {
                webRoot = Path.Combine(_environment.ContentRootPath, "wwwroot");
            }

            // Ensure wwwroot exists
            if (!Directory.Exists(webRoot))
            {
                Directory.CreateDirectory(webRoot);
            }

            // ==========================
            // Save Image
            // ==========================
            if (dto.Issueimage != null && dto.Issueimage.Length > 0)
            {
                string imageFolder = Path.Combine(webRoot, "uploads", "images");

                Directory.CreateDirectory(imageFolder);

                string imageFileName =
                    $"{Guid.NewGuid()}{Path.GetExtension(dto.Issueimage.FileName)}";

                string imageFullPath = Path.Combine(imageFolder, imageFileName);

                using (var stream = new FileStream(imageFullPath, FileMode.Create))
                {
                    await dto.Issueimage.CopyToAsync(stream);
                }

                imagePath = $"uploads/images/{imageFileName}";
            }

            // ==========================
            // Save Video
            // ==========================
            if (dto.Issuevideo != null && dto.Issuevideo.Length > 0)
            {
                string videoFolder = Path.Combine(webRoot, "uploads", "videos");

                Directory.CreateDirectory(videoFolder);

                string videoFileName =
                    $"{Guid.NewGuid()}{Path.GetExtension(dto.Issuevideo.FileName)}";

                string videoFullPath = Path.Combine(videoFolder, videoFileName);

                using (var stream = new FileStream(videoFullPath, FileMode.Create))
                {
                    await dto.Issuevideo.CopyToAsync(stream);
                }

                videoPath = $"uploads/videos/{videoFileName}";
            }

            var feedback = new UserFeedback
            {
                ServiceName = dto.ServiceName,
                Issue = dto.Issue,
                ProblemStatus = "Pending",
                CreatedAt = DateTime.Now,
                Issueimage = imagePath,
                Issuevideo = videoPath
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