using Bonyan.BNB.DDD.Domain.Entities;
using Bonyan.BNB.DDD.Domain.Repository;
using MongoDB.Driver;

namespace Bonyan.BNB.DDD.Domain.MongoDb;

public interface IMongoReadonlyRepository<TEntity, in TKey> : IReadOnlyRepository<TEntity,TKey> where TEntity : IBnbEntity<TKey>
{
    public IMongoCollection<TEntity> Collection { get; set; } 
}