using Microsoft.EntityFrameworkCore;
using Students.Domain.Students;

namespace Students.Application.Data;

public interface IStudentsDbContext
{
    DbSet<Student> Students { get; }
    DbSet<Ticket> Tickets { get; }
}