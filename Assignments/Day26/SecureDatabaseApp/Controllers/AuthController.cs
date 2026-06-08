using Microsoft.AspNetCore.Mvc;
using SecureDatabaseApp.Models;
using SecureDatabaseApp.Services;

namespace SecureDatabaseApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _service;

    public AuthController(IAuthService service)
    {
        _service = service;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto model)
    {
        return Ok(await _service.RegisterAsync(model));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto model)
    {
        var token = await _service.LoginAsync(model);

        if (token == null)
        {
            return Unauthorized();
        }

        return Ok(token);
    }
}