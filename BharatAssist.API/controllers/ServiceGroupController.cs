using BharatAssist.API.DTOs;
using BharatAssist.Infrastructure.Data;
using BharatAssist.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BharatAssist.API.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ServiceGroupController : ControllerBase
{
    private readonly BharatAssistDbContext _context;

    public ServiceGroupController(BharatAssistDbContext context)
    {
        _context = context;
    }

    [HttpGet("{categoryId}")]
    public async Task<IActionResult> Get(int categoryId)
    {
        var groups = await _context.ServiceGroups

            .Where(x => x.CategoryId == categoryId)

            .OrderBy(x => x.DisplayOrder)

            .Select(x => new ServiceGroupDto
            {
                ServiceGroupId = x.ServiceGroupId,
                GroupName = x.GroupName,
                Icon = x.Icon,
                CategoryId = x.CategoryId
            })

            .ToListAsync();

        return Ok(new ApiResponse<List<ServiceGroupDto>>
        {
            Success = true,
            Message = "Success",
            Data = groups
        });
    }
}