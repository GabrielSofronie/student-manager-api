using Microsoft.EntityFrameworkCore;
using UserAccess.Domain.User;
using UserAccess.Domain.User.Exceptions;
using UserAccess.Infrastructure.Data;

namespace UserAccess.Infrastructure.Domain;

public sealed class StudentRepository : IUserRepository<Student>
{
    private readonly UsersDbContext _dbCtx;

    public StudentRepository(UsersDbContext dbCtx) => _dbCtx = dbCtx;

    public async Task UpdatePassword(string email, string password)
    {
        var model = await _dbCtx.Students.SingleOrDefaultAsync(i => i.Email == email);
        if (model == default)
            throw new UserNotFoundException($"Cannot find user of type: <Student> with email: {email}.");

        model.ResetEmail();
        model.UpdatePassword(password);
        _dbCtx.Students.Update(model);
        await _dbCtx.SaveChangesAsync();
    }

    public async Task<IDictionary<Guid, string>> WithEmail(string email)
    {
        var model = await _dbCtx.Students.SingleOrDefaultAsync(i => i.Email == email);
        if (model == default)
            return new Dictionary<Guid, string>();

        var result = new Dictionary<Guid, string>
            {
                { model.Id, model.Password }
            };

        return await Task.FromResult(result);
    }
}