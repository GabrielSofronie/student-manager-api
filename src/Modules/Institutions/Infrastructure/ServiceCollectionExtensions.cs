using Common.Application.Handlers;
using Institutions.Domain.Institutions;
using Institutions.Domain.Students;
using Institutions.Infrastructure.Domain.Institutions;
using Institutions.Infrastructure.Domain.Students;
using Institutions.Infrastructure.Processing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Institutions.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("TicketManagerDb");
        var serverVersion = ServerVersion.AutoDetect(connectionString);

        services.AddDbContext<InstitutionsContext>(opts =>
            opts.UseMySql(connectionString,
                serverVersion,
                providerOptions => providerOptions.EnableRetryOnFailure()));

        services.AddRepositories();

        return services;
    }

    public static IServiceCollection AddLoggingCommandHandler(this IServiceCollection services)
        => services
            .AddSingleton(typeof(LoggingCommandHandler<,>), typeof(ICommandHandler<,>))
            ;

    private static IServiceCollection AddRepositories(this IServiceCollection services)
        => services
            .AddScoped<IStudentRepository, StudentRepository>()
            .AddScoped<IInstitutionRepository, InstitutionRepository>()
            ;
}