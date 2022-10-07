using Institutions.Domain.Institutions;

namespace Institutions.Infrastructure.Domain.Institutions
{
    public class InstitutionRepository : IInstitutionRepository
    {
        private readonly InstitutionsContext _institutionContext;

        public InstitutionRepository(InstitutionsContext institutionsContext) => _institutionContext = institutionsContext;

        public async Task AddAsync(Institution institution)
        {
            await _institutionContext.Institutions.AddAsync(institution);
        }

        public async Task<int> Commit()
        {
            return await _institutionContext.SaveChangesAsync();
        }

        public async Task<Institution> FindAsync(InstitutionId id)
        {
            return await _institutionContext.Institutions.FindAsync(id) ?? Institution.Default();
        }
    }
}