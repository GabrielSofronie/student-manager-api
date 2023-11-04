using System;
using System.Threading;
using System.Threading.Tasks;
using Students.Application.Students.GetStudentInfo;
using Students.Domain.Students;
using Students.Infrastructure.Data;
using Students.Tests.IntegrationTests.Fixtures;
using Xunit;

namespace Students.Tests.IntegrationTests.Students;

public class GetStudentInfoQueryHandlerTests
{
    private readonly GetStudentInfoScenario _scenario = new();
    private readonly GetStudentInfoQueryHandler _sut;

    public GetStudentInfoQueryHandlerTests() => _sut = new GetStudentInfoQueryHandler(_scenario.Context());

    [Fact]
    public async Task Handle_ShouldFindExistingStudent()
    {
        await _scenario.SetupForSuccess();
        var request = new GetStudentInfoQuery(_scenario.StudentId);
        var info = await _sut.Handle(request, CancellationToken.None);

        Assert.Equal(_scenario.StudentId, info.Id);
        Assert.NotEmpty(info.StudentName);

        await _scenario.Reset();
    }
}

internal class GetStudentInfoScenario
{
    public Guid StudentId = Guid.NewGuid();

    private readonly DbFixture _dbFixture = new();
    private readonly StudentsDbContext _ctx;

    public GetStudentInfoScenario() => _ctx = _dbFixture.CreateContext();

    public StudentsDbContext Context() => _ctx;

    public Task SetupForSuccess()
    {
        var student = new Student(StudentId, "Student Name", "email@example.com", "Institution Name", "111_222", DateTime.UtcNow);
        var ticket = new Ticket(StudentId, "code", 11, DateTime.UtcNow);

        _ctx.Add(student);
        _ctx.Add(ticket);

        return _ctx.SaveChangesAsync();
    }

    public async Task Reset()
    {
        _ctx.Students.RemoveRange(_ctx.Students);
        _ctx.Tickets.RemoveRange(_ctx.Tickets);

        await _ctx.SaveChangesAsync();
    }
}