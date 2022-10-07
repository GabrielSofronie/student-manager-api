using Common.Application.Contracts;

namespace Institutions.Application.Institutions.RegisterInstitution;

public record RegisterInstitutionCommand : ICommand<Guid>
{
    public string Email { get; init; }

    public string Password { get; init; }

    public string Name { get; init; }

    public string Code { get; init; }

    public string City { get; init; }

    public string Address { get; init; }

    public string Ownership { get; init; }

    public static RegisterInstitutionCommand Create(string email, string password, string name, string code, string city, string address, string ownership)
    {
        return new RegisterInstitutionCommand
        {
            Email = email,
            Password = password,
            Name = name,
            Code = code,
            City = city,
            Address = address,
            Ownership = ownership
        };
    }
}