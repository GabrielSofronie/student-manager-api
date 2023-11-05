using Institutions.Application.Institutions.GetInstitutionInfo;
using Institutions.Domain.Institutions;
using Institutions.Domain.Students;
using Institutions.Infrastructure;
using Institutions.Tests.IntegrationTests.Fixtures;

namespace Institutions.Tests.IntegrationTests.Institutions;

public class GetInstitutionInfoQueryHandlerTests
{
    private readonly GetInstitutionInfoScenario _scenario = new();
    private readonly GetInstitutionInfoQueryHandler _sut;

    public GetInstitutionInfoQueryHandlerTests() => _sut = new GetInstitutionInfoQueryHandler(_scenario.Context());

    [Fact]
    public async Task Handle_ShouldFindExistingInstitution()
    {
        var institutionId = await _scenario.SetupForSuccess();
        var request = new GetInstitutionInfoQuery(institutionId.Id);
        var info = await _sut.Handle(request, CancellationToken.None);

        Assert.Equal(institutionId.Id, info.Id);
        Assert.NotEmpty(info.Code);
        Assert.NotEmpty(info.Students);

        await _scenario.Reset();
    }
}

internal class GetInstitutionInfoScenario
{
    private readonly DbFixture _dbFixture = new();
    private readonly InstitutionsContext _ctx;

    public GetInstitutionInfoScenario() => _ctx = _dbFixture.CreateContext();

    public InstitutionsContext Context() => _ctx;

    public async Task<InstitutionId> SetupForSuccess()
    {
        var institution = Institution.Create("email@institution.com", "pass", "Institution Name", "I_CODE", "City", "Addr", "Public");
        var student = Student.Create(institution.Id, "Student Name", "Institution Name", "S_CODE", "111_222");

        _ctx.Add(institution);
        _ctx.Add(student);

        await _ctx.SaveChangesAsync();

        return institution.Id;
    }

    public async Task Reset()
    {
        _ctx.Students.RemoveRange(_ctx.Students);
        _ctx.Institutions.RemoveRange(_ctx.Institutions);

        await _ctx.SaveChangesAsync();
    }
}