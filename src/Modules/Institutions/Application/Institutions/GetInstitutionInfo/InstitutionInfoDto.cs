namespace Institutions.Application.Institutions.GetInstitutionInfo;

public sealed record InstitutionInfoDto(Guid Id, string Code, IEnumerable<StudentInfoDto> Students) { }

public sealed record StudentInfoDto(Guid Id, string Name, string RegistrationNumber, byte DiscountType) { }