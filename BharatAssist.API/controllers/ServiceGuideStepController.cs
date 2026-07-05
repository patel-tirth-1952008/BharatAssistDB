using BharatAssist.API.DTOs;
using BharatAssist.Infrastructure.Data;
using BharatAssist.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BharatAssist.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServiceGuideStepController : ControllerBase
{
    private readonly BharatAssistDbContext _context;

    public ServiceGuideStepController(BharatAssistDbContext context)
    {
        _context = context;
    }

    [HttpGet("{serviceId}")]
    public async Task<IActionResult> Get(int serviceId)
    {
        var steps = await _context.ServiceGuideSteps

            .Where(x => x.ServiceId == serviceId)

            .OrderBy(x => x.StepNumber)

            .Select(x => new ServiceGuideStepDto
            {
                StepId = x.StepId,
                ServiceId = x.ServiceId,
                StepNumber = x.StepNumber,
                Screenshot = x.Screenshot,
                WarningText = x.WarningText,
                Tip = x.Tip,
                AndroidGuide = x.AndroidGuide,


            })

            .ToListAsync();

        return Ok(new ApiResponse<List<ServiceGuideStepDto>>
        {
            Success = true,
            Message = "Success",
            Data = steps
        });
    }
}