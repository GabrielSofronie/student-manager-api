using Common.Domain;

namespace Students.Domain.Students;

public sealed class Student : Entity
{
    public string Name { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string Faculty { get; private set; } = string.Empty;
    public string RegistrationNumber { get; private set; } = string.Empty;
    public DateTime CreatedAt { get; private set; }

    public Student(Guid id, string name, string email, string faculty, string registrationNumber, DateTime createdAt)
    {
        Id = id;
        Name = name;
        Email = email;
        Faculty = faculty;
        RegistrationNumber = registrationNumber;
        CreatedAt = createdAt;
    }
}