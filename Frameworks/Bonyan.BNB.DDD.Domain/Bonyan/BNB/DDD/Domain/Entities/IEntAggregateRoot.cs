namespace Bonyan.BNB.Domain.Entities;

public interface IEntAggregateRoot : IBnbEntity
{
    
}

public interface IEntAggregateRoot<TKey> : IBnbEntity<TKey>, IEntAggregateRoot
{
    
}
