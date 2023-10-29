namespace UserAccess.Domain.User;

public interface IUserRepository<TUser> where TUser : User
{
    Task<IDictionary<Guid, string>> WithEmail(string email);

    Task UpdatePassword(string email, string password);
}