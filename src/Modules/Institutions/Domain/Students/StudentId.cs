using Domain;

namespace Institutions.Domain.Students;

public sealed class StudentId : Identity
{
    public StudentId() : base() { }

    public StudentId(Guid id) : base(id) { }
}