namespace UserAccess.Application.Authenticate;

public sealed record AuthenticationResult
{
    public Guid Id { get; }
    public string Token { get; }
    public long TokenExpirationTime { get; }

    public AuthenticationResult(Guid id, string token, long tokenExpirationTime)
    {
        Id = id;
        Token = token;
        TokenExpirationTime = tokenExpirationTime;
    }

    public static AuthenticationResult Default()
    {
        return new AuthenticationResult(Guid.Empty, string.Empty, 0);
    }
}