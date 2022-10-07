using AutoFixture;
using Institutions.Application.Students.ImportStudents;
using Institutions.Domain.Institutions;
using Institutions.Domain.Students;
using Institutions.Tests.IntegrationTests.Shared;

namespace Institutions.Tests.IntegrationTests.Students;

public class ImportStudentsBatchTests : IClassFixture<TestFixture>
{
    private readonly TestFixture _testFixture;
    private readonly Fixture _fixture = new();

    public ImportStudentsBatchTests(TestFixture testFixture) => _testFixture = testFixture;

    [Fact]
    public async Task Import()
    {
        var institutionRepo = _testFixture.GetService<IInstitutionRepository>();
        var studentRepo = _testFixture.GetService<IStudentRepository>();

        var institution = Institution.Create(
            _fixture.Create<string>(),
            _fixture.Create<string>(),
            _fixture.Create<string>(),
            _fixture.Create<string>(),
            _fixture.Create<string>(),
            _fixture.Create<string>(),
            _fixture.Create<string>(),
            _fixture.Create<string>()
        );
        await institutionRepo.AddAsync(institution);
        await institutionRepo.Commit();

        var studentDetails = _fixture.CreateMany<StudentDetails>(5).ToArray();
        var cmd = ImportStudentsBatchCommand.Create(institution.Id.Id, studentDetails);

        var handler = new ImportStudentsBatchCommandHandler(institutionRepo, studentRepo);

        var importedStudents = await handler.Handle(cmd, CancellationToken.None);

        Assert.Equal(studentDetails.Length, importedStudents);
    }
}