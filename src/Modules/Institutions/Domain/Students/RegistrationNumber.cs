namespace Institutions.Domain.Students;

public record RegistrationNumber(string Code, string Number)
{
    private const string separator = "_";

    public static RegistrationNumber Create(string code, string number)
    {
        if (string.IsNullOrEmpty(code))
        {
            throw new ArgumentException($"{nameof(code)} must have a value.");
        }

        if (string.IsNullOrEmpty(number))
        {
            throw new ArgumentException($"{nameof(number)} must have a value.");
        }

        return new(code, number);
    }

    public static RegistrationNumber From(string registrationNumber)
    {
        var parts = registrationNumber.Split(separator);
        return Create(parts[0], parts[1]);
    }

    public override string ToString() => $"{Code}{separator}{Number}";
}