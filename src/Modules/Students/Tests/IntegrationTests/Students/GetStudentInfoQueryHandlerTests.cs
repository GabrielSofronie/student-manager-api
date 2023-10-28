using System;
using System.Threading;
using System.Threading.Tasks;
using Students.Application.Students.GetStudentInfo;
using Students.Tests.IntegrationTests.Fixtures;
using Xunit;

namespace Students.Tests.IntegrationTests.Students;

public class GetStudentInfoQueryHandlerTests
{
    private readonly DbFixture _dbFixture = new DbFixture();
    private readonly GetStudentInfoQueryHandler _sut;

    public GetStudentInfoQueryHandlerTests()
    {
        _sut = new GetStudentInfoQueryHandler(
            _dbFixture.CreateContext()
        );
    }

    [Fact]
    public async Task HandleInfo()
    {
        var request = new GetStudentInfoQuery(Guid.NewGuid());
        var info = await _sut.Handle(request, CancellationToken.None);

        return;
    }
}