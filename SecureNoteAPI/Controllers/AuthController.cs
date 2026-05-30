using BCrypt.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureNoteAPI.Data;
using SecureNoteAPI.DTOs;
using SecureNoteAPI.Models;
using SecureNoteAPI.Services;

namespace SecureNoteAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IJwtService _jwtService;

    public AuthController(
        AppDbContext context,
        IJwtService jwtService)
    {
        _context = context;
        _jwtService = jwtService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        if (await _context.Users
            .AnyAsync(x => x.Username == dto.Username))
        {
            return BadRequest(
                "Username already exists");
        }

        var user = new User
        {
            Username = dto.Username,
            PasswordHash =
                BCrypt.Net.BCrypt.HashPassword(dto.Password)
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return Ok(new
        {
            message =
            "User registered successfully. Please log in."
        });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(
                x => x.Username == dto.Username);

        if (user == null)
            return Unauthorized();

        bool valid =
            BCrypt.Net.BCrypt.Verify(
                dto.Password,
                user.PasswordHash);

        if (!valid)
            return Unauthorized();

        var token =
            _jwtService.GenerateToken(user);

        return Ok(new
        {
            token,
            expires_in = 3600,
            user = new
            {
                user.Username
            }
        });
    }
}