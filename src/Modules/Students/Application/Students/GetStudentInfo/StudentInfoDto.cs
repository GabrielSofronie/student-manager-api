namespace Students.Application.Students.GetStudentInfo;

public sealed record StudentInfoDto(Guid Id, string StudentName, string Faculty, string Code, byte DiscountType, DateTime CreatedAt) { }