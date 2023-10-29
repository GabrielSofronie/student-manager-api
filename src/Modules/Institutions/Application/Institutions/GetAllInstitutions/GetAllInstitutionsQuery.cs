using Common.Application.Contracts;

namespace Institutions.Application.Institutions.GetAllInstitutions;

public sealed record GetAllInstitutionsQuery : IQuery<InstitutionsDto> { }