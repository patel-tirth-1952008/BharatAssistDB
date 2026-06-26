using BharatAssist.API.DTOs;
using BharatAssist.Infrastructure.Data;
using BharatAssist.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BharatAssist.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommunityTipController : ControllerBase
{
    private readonly BharatAssistDbContext _context;

    public CommunityTipController(BharatAssistDbContext context)
    {
        _context = context;
    }

    [HttpGet("{serviceId}")]
    public async Task<IActionResult> Get(int serviceId)
    {
        var data = await _context.CommunityTips

            .Where(x => x.ServiceId == serviceId)

            .Select(x => new CommunityTipDto
            {
                CommunityTipId = x.CommunityTipId,
                Problem = x.Problem,
                Solution = x.Solution,
                Votes = x.Votes
            })

            .ToListAsync();

        return Ok(new ApiResponse<List<CommunityTipDto>>
        {
            Success = true,
            Message = "Success",
            Data = data
        });
    }
}