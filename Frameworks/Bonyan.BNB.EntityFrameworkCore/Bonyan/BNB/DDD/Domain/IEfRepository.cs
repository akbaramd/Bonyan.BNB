using Bonyan.BNB.DDD.Domain.Entities;
using Bonyan.BNB.DDD.Domain.Repository;

namespace Bonyan.BNB.DDD.Domain;

public interface IEfRepository<TEntity, in TKey> : 
    IEfReadonlyRepository<TEntity,TKey>,
    IRepository<TEntity,TKey> where TEntity : IBnbEntity<TKey>
{
    
}
