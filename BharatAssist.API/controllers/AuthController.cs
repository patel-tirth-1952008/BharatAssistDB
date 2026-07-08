using BharatAssist.API.DTOs;
using BharatAssist.Core.Entities;
using BharatAssist.Infrastructure.Data;
using BharatAssist.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BharatAssist.API.Services;
namespace BharatAssist.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly BharatAssistDbContext _context;
    private readonly JwtService _jwtService;

    public AuthController(
        BharatAssistDbContext context,
        JwtService jwtService)
    {
        _context = context;
        _jwtService = jwtService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        if (await _context.Users.AnyAsync(x => x.Email == dto.Email))
            return BadRequest("Email already exists");

        var user = new User
{
            FullName = dto.FullName,
            Email = dto.Email,
            Mobile = "",
            PasswordHash = dto.Password,
            Points = 0,
            LevelName = "Beginner",
            Badge = "Bronze",
            JoinDate = DateTime.UtcNow
};

        _context.Users.Add(user);

        await _context.SaveChangesAsync();

        return Ok(new ApiResponse<string>
        {
            Success = true,
            Message = "Registered Successfully",
            Data = ""
        });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x =>
            x.Email == dto.Email &&
            x.PasswordHash == dto.Password);

        if (user == null)
            return Unauthorized();

        var token = _jwtService.GenerateToken(user);

        return Ok(new
        {
            token = token
        });
    }
}