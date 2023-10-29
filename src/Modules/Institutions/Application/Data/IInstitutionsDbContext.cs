using Institutions.Domain.Institutions;
using Institutions.Domain.Students;
using Microsoft.EntityFrameworkCore;

namespace Institutions.Application.Data;

public interface IInstitutionsDbContext
{
    DbSet<Institution> Institutions { get; }
    DbSet<Student> Students { get; }
}