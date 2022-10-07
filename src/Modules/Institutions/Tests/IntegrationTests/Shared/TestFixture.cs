using Institutions.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Institutions.Tests.IntegrationTests.Shared;

public class TestFixture : IDisposable
{
    private readonly IServiceProvider _serviceProvider;

    public TestFixture()
    {
        var cfg = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string>
            {
                {"ConnectionStrings:TicketManagerDb", "server=localhost;port=3306;database=test_db;uid=root;password=access"}
            })
            .Build();

        _serviceProvider = new ServiceCollection()
            .AddPersistence(cfg)
            .BuildServiceProvider();
    }

    public T GetService<T>()
    {
        return _serviceProvider.GetService<T>() ?? throw new TypeLoadException();
    }

    public void Dispose() { }
}