using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Students.Infrastructure.Data;

namespace Students.Tests.IntegrationTests.Fixtures;

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

    public StudentsDbContext CreateContext() => new(_connectionString);
}