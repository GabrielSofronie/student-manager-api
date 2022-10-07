namespace Domain;

public abstract class Identity : IIdentity
{
    public Guid Id { get; private set; }

    public Identity() => Id = Guid.NewGuid();

    public Identity(Guid id) => Id = id;
}