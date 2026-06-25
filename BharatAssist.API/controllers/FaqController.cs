using BharatAssist.API.DTOs;
using BharatAssist.Infrastructure.Data;
using BharatAssist.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BharatAssist.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FaqController : ControllerBase
{
    private readonly BharatAssistDbContext _context;

    public FaqController(BharatAssistDbContext context)
    {
        _context = context;
    }

    [HttpGet("{serviceId}")]
    public async Task<IActionResult> Get(int serviceId)
    {
        var data = await _context.Faqs

            .Where(x => x.ServiceId == serviceId)

            .Select(x => new FaqDto
            {
                FaqId = x.FaqId,
                Question = x.Question,
                Answer = x.Answer
            })

            .ToListAsync();

        return Ok(new ApiResponse<List<FaqDto>>
        {
            Success = true,
            Message = "Success",
            Data = data
        });
    }
}