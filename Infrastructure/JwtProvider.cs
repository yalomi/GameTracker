using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Interfaces;
using Core.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure;

public class JwtProvider(IOptions<JwtOptions> options) : IJwtProvider
{
    private readonly JwtOptions _options = options.Value;

    public string GenerateToken(User user)
    {
        Claim[] claims = [new Claim("userId", user.Id.ToString())];
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey)), SecurityAlgorithms.HmacSha256);
        
        var token = new JwtSecurityToken(
            signingCredentials: signingCredentials,
            expires: DateTime.Now.AddMinutes(_options.ExpiresInMinutes),
            claims: claims
            );
        
        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
        return tokenString;
    }
}

public class JwtOptions
{
    public string SecretKey { get; set; } = string.Empty;
    public int ExpiresInMinutes { get; set; } 

}