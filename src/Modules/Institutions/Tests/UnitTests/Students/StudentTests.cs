using Institutions.Domain.Institutions;
using Institutions.Domain.Students;

namespace Institutions.UnitTests.Students;

public class StudentTests
{
    [Fact]
    public void CreateStudent_IsSuccessful()
    {
        var institutionId = new InstitutionId();
        var student = Student.Create(
            institutionId,
            "studentName",
            "studentFaculty",
            "studentCode",
            "studentNumber",
            10
        );

        Assert.False(student.IsDefault());
    }
}