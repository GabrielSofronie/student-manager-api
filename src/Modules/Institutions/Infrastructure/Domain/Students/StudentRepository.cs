using Institutions.Domain.Students;

namespace Institutions.Infrastructure.Domain.Students;

public sealed class StudentRepository : IStudentRepository
{
    private readonly InstitutionsContext _institutionContext;

    public StudentRepository(InstitutionsContext institutionsContext) => _institutionContext = institutionsContext;

    public async Task AddAsync(Student student)
    {
        await _institutionContext.Students.AddAsync(student);
    }

    public async Task<int> Commit()
    {
        return await _institutionContext.SaveChangesAsync();
    }

    public async Task<Student> FindAsync(StudentId id)
    {
        return await _institutionContext.Students.FindAsync(id) ?? Student.Default();
    }

    public async Task<Student> FindAsync(RegistrationNumber registrationNumber)
    {
        throw new NotImplementedException();
    }

    public async Task RemoveAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task RemoveAsync(Student student)
    {
        throw new NotImplementedException();
    }
}