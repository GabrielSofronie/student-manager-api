using UserAccess.Domain.User;

namespace UserAccess.Infrastructure.Domain;

public sealed class ManagerRepository : IUserRepository<Manager>
{
    private const string ManagerGuid = "00000000-1111-1111-1111-000000000000";
    private readonly IDictionary<string, string> _users = new Dictionary<string, string>
        {
            { "it.olariu@sctpiasi.ro", "AQAAAAEAACcQAAAAEJXWLaXD5BOFttC5sf2TUOt0ANkashZAKaYzpbPHWKc7qG6/pHpjlOq0SPNFXOVN6w==" }
        };

    public Task UpdatePassword(string email, string password)
    {
        throw new NotImplementedException();
    }

    public async Task<IDictionary<Guid, string>> WithEmail(string email)
    {
        var user = _users.FirstOrDefault(u => u.Key == email);

        if (user.Value == default)
            return new Dictionary<Guid, string>();

        var id = Guid.Parse(ManagerGuid);
        var result = new Dictionary<Guid, string>
            {
                { id, user.Value }
            };

        return await Task.FromResult(result);
    }
}