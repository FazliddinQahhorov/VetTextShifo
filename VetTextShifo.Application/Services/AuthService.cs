using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VetTextShifo.Application.Interfaces;
using VetTextShifo.Data.Interfaces;
using VetTextShifo.Domain.Entities;

namespace VetTextShifo.Application.Services;

public class AuthService : IAuthService
{
    private readonly IGenericRepository<Admin> userRepository;
    private readonly IConfiguration configuration;

    public AuthService(IGenericRepository<Admin> userRepository, IConfiguration configuration)
    {
        this.userRepository = userRepository;
        this.configuration = configuration;
    }
    public async Task<string> GenerateToken(Admin admin)
    {

        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

        byte[] tokenKey = Encoding.UTF8.GetBytes(configuration["JWT:SecretKey"]);

        SecurityTokenDescriptor tokenDescription = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                    new Claim(ClaimTypes.Email, admin.email),
            }),
            Expires = DateTime.UtcNow.AddMinutes(int.Parse(configuration["JWT:Lifetime"])),
            Issuer = configuration["JWT:Issuer"],
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256)
        };
        var token = tokenHandler.CreateToken(tokenDescription);

        return tokenHandler.WriteToken(token);


    }
}
