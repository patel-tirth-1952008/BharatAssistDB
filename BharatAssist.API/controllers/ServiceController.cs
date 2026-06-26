using BharatAssist.API.DTOs;
using BharatAssist.Infrastructure.Data;
using BharatAssist.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BharatAssist.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServiceController : ControllerBase
{
    private readonly BharatAssistDbContext _context;

    public ServiceController(BharatAssistDbContext context)
    {
        _context = context;
    }

    [HttpGet("{groupId}")]
    public async Task<IActionResult> Get(int groupId)
    {
        var services = await _context.Services

            .Where(x => x.ServiceGroupId == groupId)

            .OrderBy(x => x.ServiceName)

            .Select(x => new ServiceDto
            {
                ServiceId = x.ServiceId,
                ServiceName = x.ServiceName,
                Description = x.Description,
                GovernmentFee = x.GovernmentFee,
                EstimatedMinutes = x.EstimatedMinutes,
                Difficulty = x.Difficulty
            })

            .ToListAsync();

        return Ok(new ApiResponse<List<ServiceDto>>
        {
            Success = true,
            Message = "Success",
            Data = services
        });
    }
}