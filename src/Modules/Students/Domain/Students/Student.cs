using Common.Domain;

namespace Students.Domain.Students;

public sealed class Student : Entity
{
    public string Name { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string Faculty { get; private set; } = string.Empty;
    public string Code { get; private set; } = string.Empty;
    public byte DiscountType { get; private set; }
    public DateTime CreatedAt { get; private set; }
}