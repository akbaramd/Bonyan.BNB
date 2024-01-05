using Bonyan.BNB.DDD.Domain.Entities;
using Bonyan.BNB.DDD.Domain.Repository;

namespace Bonyan.BNB.DDD.Domain.MongoDb;

public interface IMongoRepository<TEntity, in TKey> : 
    IMongoReadonlyRepository<TEntity,TKey>,
    IRepository<TEntity,TKey> where TEntity : IBnbEntity<TKey>
{
    
}