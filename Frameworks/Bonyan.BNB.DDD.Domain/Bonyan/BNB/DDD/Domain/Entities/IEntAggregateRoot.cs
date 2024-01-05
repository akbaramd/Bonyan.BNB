namespace Bonyan.BNB.DDD.Domain.Entities;

public interface IBnbAggregateRoot : IBnbEntity
{
    
}

public interface IBnbAggregateRoot<TKey> : IBnbEntity<TKey>, IBnbAggregateRoot
{
    
}
