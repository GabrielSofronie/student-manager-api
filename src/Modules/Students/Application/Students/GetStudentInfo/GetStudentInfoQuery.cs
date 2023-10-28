using Common.Application.Contracts;

namespace Students.Application.Students.GetStudentInfo;

public sealed record GetStudentInfoQuery : IQuery<StudentInfoDto>
{
    public Guid Id { get; init; }

    public GetStudentInfoQuery(Guid id)
    {
        Id = id;
    }
}