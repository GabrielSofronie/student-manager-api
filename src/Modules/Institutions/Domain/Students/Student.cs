using Common.Domain;
using Institutions.Domain.Institutions;

namespace Institutions.Domain.Students;

public sealed class Student : Entity, IAggregateRoot
{
    public StudentId Id { get; init; } = new StudentId(Guid.Empty);

    private readonly InstitutionId _institutionId;

    private readonly string _name;

    private string _email;

    private string _password;

    private readonly string _faculty;

    private readonly RegistrationNumber _registrationNumber;

    private readonly DateTime _createdAt;

    private DateTime _login;

    private readonly string _code;

    private readonly byte _discountType;

    private Student() { }

    private Student(StudentId id, InstitutionId institutionId, string name, string faculty, RegistrationNumber registrationNumber, string code, byte discountType)
    {
        Id = id;
        _institutionId = institutionId;
        _name = name;
        _faculty = faculty;
        _registrationNumber = registrationNumber;
        _code = code;
        _discountType = discountType;
        _createdAt = DateTime.UtcNow;
    }

    public static Student Create(InstitutionId institutionId, string name, string faculty, string code, string number, byte discountType)
    {
        var regNo = RegistrationNumber.Create(code, number);

        var fromData = $"{institutionId.Id}{name}{regNo}";
        var id = GeneratorHelper.NewGuid(fromData);
        var ticketCode = GeneratorHelper.NewCode();

        return new Student(
            new StudentId(id),
            institutionId,
            name,
            faculty,
            regNo,
            ticketCode,
            discountType
        );
    }

    public static Student Default() => new();

    public bool IsDefault() => Id.Equals(new StudentId(Guid.Empty));
}
