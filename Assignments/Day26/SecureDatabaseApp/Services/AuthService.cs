using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SecureDatabaseApp.Models;
using SecureDatabaseApp.Repositories;
using SecureDatabaseApp.Security;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SecureDatabaseApp.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _repository;
    private readonly EncryptionService _encryptionService;
    private readonly IConfiguration _configuration;

    public AuthService(
        IUserRepository repository,
        EncryptionService encryptionService,
        IConfiguration configuration)
    {
        _repository = repository;
        _encryptionService = encryptionService;
        _configuration = configuration;
    }

    public async Task<string> RegisterAsync(RegisterDto model)
    {
        var existingUser =
            await _repository.GetByEmailAsync(model.Email);

        if (existingUser != null)
        {
            return "User already exists";
        }

        var user = new User
        {
            Name = model.Name,
            Email = model.Email,
            PasswordHash =
                PasswordHasher.HashPassword(model.Password),
            Role = "User",
            EncryptedFinancialData =
                _encryptionService.Encrypt(model.FinancialData)
        };

        await _repository.AddAsync(user);
        await _repository.SaveChangesAsync();

        return "User Registered Successfully";
    }

    public async Task<string?> LoginAsync(LoginDto model)
    {
        var user =
            await _repository.GetByEmailAsync(model.Email);

        if (user == null)
        {
            return null;
        }

        bool validPassword =
            PasswordHasher.VerifyPassword(
                model.Password,
                user.PasswordHash);

        if (!validPassword)
        {
            return null;
        }

        return GenerateToken(user);
    }

    private string GenerateToken(User user)
    {
        var key = Encoding.UTF8.GetBytes(
            _configuration["Jwt:Key"]!);

        var claims = new[]
        {
            new Claim(ClaimTypes.Name,user.Email),
            new Claim(ClaimTypes.Role,user.Role)
        };

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials:
                new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256)
        );

        return new JwtSecurityTokenHandler()
            .WriteToken(token);
    }
}