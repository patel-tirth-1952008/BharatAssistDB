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

            // ==========================
            // Save Image
            // ==========================

            if (dto.Issueimage != null && dto.Issueimage.Length > 0)
            {
                string imageFolder = Path.Combine(
                    _environment.WebRootPath,
                    "uploads",
                    "images");

                if (!Directory.Exists(imageFolder))
                {
                    Directory.CreateDirectory(imageFolder);
                }

                string imageFileName =
                    Guid.NewGuid().ToString() +
                    Path.GetExtension(dto.Issueimage.FileName);

                string imageFullPath =
                    Path.Combine(imageFolder, imageFileName);

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
                string videoFolder = Path.Combine(
                    _environment.WebRootPath,
                    "uploads",
                    "videos");

                if (!Directory.Exists(videoFolder))
                {
                    Directory.CreateDirectory(videoFolder);
                }

                string videoFileName =
                    Guid.NewGuid().ToString() +
                    Path.GetExtension(dto.Issuevideo.FileName);

                string videoFullPath =
                    Path.Combine(videoFolder, videoFileName);

                using (var stream = new FileStream(videoFullPath, FileMode.Create))
                {
                    await dto.Issuevideo.CopyToAsync(stream);
                }

                videoPath = $"uploads/videos/{videoFileName}";
            }

            // ==========================
            // Save Feedback
            // ==========================

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