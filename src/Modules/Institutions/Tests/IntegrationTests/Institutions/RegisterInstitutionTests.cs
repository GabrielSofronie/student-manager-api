using AutoFixture;
using Institutions.Application.Institutions.RegisterInstitution;
using Institutions.Domain.Institutions;
using Institutions.Tests.IntegrationTests.Shared;

namespace Institutions.IntegrationTests.Institutions;

public class RegisterInstitutionTests : IClassFixture<TestFixture>
{
    private readonly TestFixture _testFixture;
    private readonly Fixture _fixture = new();

    public RegisterInstitutionTests(TestFixture testFixture) => _testFixture = testFixture;

    [Fact]
    public async Task Register()
    {
        var cmd = _fixture.Create<RegisterInstitutionCommand>();

        var handler = new RegisterInstitutionCommandHandler(_testFixture.GetService<IInstitutionRepository>());

        var institutionId = await handler.Handle(cmd, CancellationToken.None);

        Assert.IsType<Guid>(institutionId);
        Assert.False(Guid.Empty.Equals(institutionId));
    }
}