namespace Bonyan.BNB.Domain.Entities;

public interface IBnbEntity
{
    object?[] GetKeys();
}

public interface IBnbEntity<TKey> : IBnbEntity
{
    TKey Id { get; }
}