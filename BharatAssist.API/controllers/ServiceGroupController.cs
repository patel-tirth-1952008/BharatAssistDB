using BharatAssist.API.DTOs;
using BharatAssist.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

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

    [HttpGet]
    public IActionResult Get()
    {
        var groups = _context.ServiceGroups
            .Select(g => new ServiceGroupDto
            {
                ServiceGroupId = g.ServiceGroupId,
                CategoryId = g.CategoryId,
                GroupName = g.GroupName,
                Icon = g.Icon
            })
            .ToList();

        return Ok(groups);
    }
}
