﻿
namespace Common.Domain;

public abstract class Entity : IIdentity
{
    public Guid Id { get; protected set; }
}
