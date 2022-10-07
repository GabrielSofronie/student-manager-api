namespace Institutions.Domain.Institutions;

public sealed class Institution
{
    public InstitutionId Id { get; init; } = new InstitutionId(Guid.Empty);

    private readonly string _email = string.Empty;

    private readonly string _password = string.Empty;

    private readonly string _name = string.Empty;

    private readonly string _code = string.Empty;

    private readonly string _city = string.Empty;

    private readonly string _address = string.Empty;

    private readonly string _ownership = string.Empty;

    private readonly string _type = string.Empty;

    private readonly DateTime _createdAt;

    private DateTime _login;

    private Institution() { }

    private Institution(string email, string password, string name, string code, string city, string address, string ownership, string type, DateTime login)
    {
        Id = new InstitutionId();
        _email = email;
        _password = password;
        _name = name;
        _code = code;
        _city = city;
        _address = address;
        _ownership = ownership;
        _type = type;
        _login = login;
        _createdAt = DateTime.UtcNow;
    }

    public static Institution Create(string email, string password, string name, string code, string city, string address, string ownership, string type)
    {
        return new Institution(email, password, name, code, city, address, ownership, type, default);
    }

    public static Institution Create(string email, string password, string name, string code, string city, string address, string ownership)
    {
        return new Institution(email, password, name, code, city, address, ownership, null, default);
    }

    public static Institution Default() => new();

    public bool IsDefault() => Id.Id.Equals(Guid.Empty);

    public string Code() => _code;
}