namespace Institutions.Domain.Institutions;

public interface IInstitutionRepository
{
    Task AddAsync(Institution institution);

    Task<Institution> FindAsync(InstitutionId id);

    Task<int> Commit();
}