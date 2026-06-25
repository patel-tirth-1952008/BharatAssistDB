using BharatAssist.API.DTOs;
using BharatAssist.Infrastructure.Data;
using BharatAssist.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BharatAssist.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RequiredDocumentController : ControllerBase
{
    private readonly BharatAssistDbContext _context;

    public RequiredDocumentController(BharatAssistDbContext context)
    {
        _context = context;
    }

    [HttpGet("{serviceId}")]
    public async Task<IActionResult> Get(int serviceId)
    {
        var data = await _context.RequiredDocuments

            .Where(x => x.ServiceId == serviceId)

            .Select(x => new RequiredDocumentDto
            {
                RequiredDocumentId = x.RequiredDocumentId,
                DocumentName = x.DocumentName,
                Mandatory = x.Mandatory
            })

            .ToListAsync();

        return Ok(new ApiResponse<List<RequiredDocumentDto>>
        {
            Success = true,
            Message = "Success",
            Data = data
        });
    }
}
