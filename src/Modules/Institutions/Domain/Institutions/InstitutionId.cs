using Common.Domain;

namespace Institutions.Domain.Institutions;

public sealed class InstitutionId : Identity
{
    public InstitutionId() : base() { }

    public InstitutionId(Guid id) : base(id) { }
}