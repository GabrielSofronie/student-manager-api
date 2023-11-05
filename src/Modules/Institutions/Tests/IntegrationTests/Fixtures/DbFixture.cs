using Institutions.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace Institutions.Tests.IntegrationTests.Fixtures;

// https://learn.microsoft.com/en-us/ef/core/testing/testing-with-the-database

internal class DbFixture
{
    private readonly string _connectionString = string.Empty;

    public DbFixture()
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();

        _connectionString = configuration.GetConnectionString("Sql") ?? string.Empty;
    }

    public InstitutionsContext CreateContext() => new(_connectionString);
}