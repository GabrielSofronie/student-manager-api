namespace Common.Domain;

public abstract class Identity : IIdentity
{
    public Guid Id { get; init; }

    public Identity() => Id = Guid.NewGuid();

    public Identity(Guid id) => Id = id;
}