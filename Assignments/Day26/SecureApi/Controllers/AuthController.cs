using Microsoft.AspNetCore.Mvc;
using SecureApi.Models;
using SecureApi.Services;

namespace SecureApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly JwtService _jwtService;

    public AuthController(JwtService jwtService)
    {
        _jwtService = jwtService;
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        User? user = null;

        if (request.Username == "admin" &&
            request.Password == "admin123")
        {
            user = new User
            {
                Username = "admin",
                Role = "Admin"
            };
        }
        else if (request.Username == "user" &&
                 request.Password == "user123")
        {
            user = new User
            {
                Username = "user",
                Role = "User"
            };
        }

        if (user == null)
            return Unauthorized("Invalid credentials");

        var token = _jwtService.GenerateToken(user);

        return Ok(new
        {
            Token = token,
            Role = user.Role
        });
    }
}