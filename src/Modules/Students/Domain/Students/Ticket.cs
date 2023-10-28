namespace Students.Domain.Students;

public sealed record Ticket(Guid OwnerId, string Code, byte DiscountType, DateTime CreatedAt)
{
}