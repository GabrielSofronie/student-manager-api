using Microsoft.EntityFrameworkCore;
using Students.Domain.Students;

namespace Students.Application.Data;

public interface IApplicationDbContext
{
    DbSet<Student> Students { get; }
    DbSet<Ticket> Tickets { get; }
}