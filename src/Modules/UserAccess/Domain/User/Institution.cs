using Common.Domain;

namespace UserAccess.Domain.User;

public sealed class Institution : Entity
{
    public string? Email { get; private set; } = string.Empty;
    public string Password { get; private set; } = string.Empty;
    public void ResetEmail() => Email = null;

    public void UpdatePassword(string password) => Password = password;
}