using Microsoft.EntityFrameworkCore;
using UserAccess.Domain.User;
using UserAccess.Domain.User.Exceptions;
using UserAccess.Infrastructure.Data;

namespace UserAccess.Infrastructure.Domain;

public sealed class InstitutionRepository : IUserRepository<Institution>
{
    private readonly UsersDbContext _dbCtx;

    public InstitutionRepository(UsersDbContext dbCtx) => _dbCtx = dbCtx;

    public async Task UpdatePassword(string email, string password)
    {
        var model = await _dbCtx.Institutions.SingleOrDefaultAsync(i => i.Email == email);
        if (model == default)
            throw new UserNotFoundException($"Cannot find user of type: <Institution> with email: {email}.");

        model.ResetEmail();
        model.UpdatePassword(password);
        _dbCtx.Institutions.Update(model);
        await _dbCtx.SaveChangesAsync();
    }

    public async Task<IDictionary<Guid, string>> WithEmail(string email)
    {
        var model = await _dbCtx.Institutions.SingleOrDefaultAsync(i => i.Email == email);
        if (model == default)
            return new Dictionary<Guid, string>();

        var result = new Dictionary<Guid, string>
            {
                { model.Id, model.Password }
            };

        return await Task.FromResult(result);
    }
}