namespace Institutions.Application.Institutions.GetAllInstitutions;

public sealed record InstitutionsDto(IEnumerable<InstitutionDto> Institutions) { }

public sealed record InstitutionDto(string Name, string Code) { }