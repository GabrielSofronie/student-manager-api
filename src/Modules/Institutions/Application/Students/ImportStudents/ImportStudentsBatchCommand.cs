using System.Collections.Immutable;
using Common.Application.Contracts;

namespace Institutions.Application.Students.ImportStudents;

public record ImportStudentsBatchCommand : ICommand<int>
{
    public Guid InstitutionId { get; init; }

    public IImmutableSet<StudentDetails> Students { get; init; } = ImmutableHashSet.Create<StudentDetails>();

    public static ImportStudentsBatchCommand Create(Guid institutionId, StudentDetails[] studentDetails)
    {
        return new ImportStudentsBatchCommand
        {
            InstitutionId = institutionId,
            Students = ImmutableHashSet.Create(studentDetails)
        };
    }

    public static ImportStudentsBatchCommand Create(Guid institutionId, StudentDetails studentDetails)
        => Create(institutionId, new[] { studentDetails });
}

public record StudentDetails(string Name, string RegistrationNumber, byte DiscountType, string Faculty)
{
}