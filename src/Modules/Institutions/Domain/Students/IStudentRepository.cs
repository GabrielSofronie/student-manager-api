namespace Institutions.Domain.Students;

public interface IStudentRepository
{
    Task AddAsync(Student student);

    Task<Student> FindAsync(StudentId id);

    Task<Student> FindAsync(RegistrationNumber registrationNumber);

    Task RemoveAsync(Student student);

    Task RemoveAllAsync();

    Task<int> Commit();
}