using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using UserAccess.Application.Authenticate;

namespace UserAccess.Infrastructure.Authenticate;

public static class DependencyInjection
{
    private const string Sec = "bRhYJRlZvBj2vW4MrV5HVdPgIE6VMtCFB0kTtJ1m";

    public static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                //options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    // TODO: PUT Validate values inside appsettings;
                    //       read settings from configuration and inside CustomAuthentication through IOptions<>
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Sec))
                };
            });

        services.AddScoped(typeof(IAuthentication<>), typeof(CustomAuthentication<>));

        return services;
    }
}