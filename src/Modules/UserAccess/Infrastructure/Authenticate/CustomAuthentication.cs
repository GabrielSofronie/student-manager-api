using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CryptoHelper;
using Microsoft.IdentityModel.Tokens;
using UserAccess.Application.Authenticate;
using UserAccess.Domain.User;

namespace UserAccess.Infrastructure.Authenticate;

public class CustomAuthentication<TUser> : IAuthentication<TUser> where TUser : User
{
    private readonly IUserRepository<TUser> _repository;

    private const string Secret = "bRhYJRlZvBj2vW4MrV5HVdPgIE6VMtCFB0kTtJ1m";
    private const int Lifespan = 86400;
    private const string Bearer = "bearer";

    public CustomAuthentication(IUserRepository<TUser> repository)
    {
        _repository = repository;
    }

    public async Task<AuthenticationResult> Authenticate(string username, string password)
    {
        var expirationTime = DateTime.UtcNow.AddSeconds(Lifespan);

        var users = await _repository.WithEmail(username);
        if (users == default)
            return AuthenticationResult.Default();

        var user = users.FirstOrDefault();
        if (user.Key == Guid.Empty)
        {
            return AuthenticationResult.Default();
        }

        if (!VerifyPassword(user.Value, password))
        {
            return AuthenticationResult.Default();
        }

        return new AuthenticationResult(user.Key, CustomAuthentication<TUser>.GenerateToken(user.Key.ToString(), expirationTime), ((DateTimeOffset)expirationTime).ToUnixTimeSeconds());
    }

    public string IdFromAuthorization(string authorization)
    {
        var token = authorization.ToString().Substring(Bearer.Length).Trim();
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secret));
        var tokenHandler = new JwtSecurityTokenHandler();

        try
        {
            var claims = tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = securityKey
            }, out var validatedToken);

            return claims.Claims.FirstOrDefault(c => c.Type == ClaimTypes.UserData)?.Value ?? string.Empty;
        }
        catch
        {
            return string.Empty;
        }
    }

    public bool ValidateId(Guid id, string authorization)
    {
        var authorizationId = IdFromAuthorization(authorization);
        return Guid.TryParse(authorizationId, out var tokenId) && tokenId == id;
    }

    public string HashPassword(string password)
    {
        return Crypto.HashPassword(password);
    }

    public bool VerifyPassword(string hashedPassword, string actualPassword)
    {
        return Crypto.VerifyHashedPassword(hashedPassword, actualPassword);
    }

    private static string GenerateToken(string id, DateTime expires)
    {
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(
                new[]
                {
                        new Claim(ClaimTypes.UserData, id)
                }),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secret)),
                    SecurityAlgorithms.HmacSha256Signature),
            Expires = expires
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
    }
}