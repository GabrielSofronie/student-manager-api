using Common.Application.Contracts;

namespace Institutions.Application.Institutions.GetInstitutionInfo;

public sealed record GetInstitutionInfoQuery : IQuery<InstitutionInfoDto>
{
    public Guid Id { get; init; }

    public GetInstitutionInfoQuery(Guid id)
    {
        Id = id;
    }
}