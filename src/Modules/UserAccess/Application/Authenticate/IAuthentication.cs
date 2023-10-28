namespace UserAccess.Application.Authenticate;

public interface IAuthentication<TUser>
{
    Task<AuthenticationResult> Authenticate(string username, string password);
    string IdFromAuthorization(string authorization);
    bool ValidateId(Guid id, string authorization);
    string HashPassword(string password);
    bool VerifyPassword(string actualPassword, string hashedPassword);
}