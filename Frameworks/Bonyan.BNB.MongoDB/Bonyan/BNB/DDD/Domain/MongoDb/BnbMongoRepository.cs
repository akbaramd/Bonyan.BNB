using Bonyan.BNB.DDD.Domain.Entities;
using Bonyan.BNB.DDD.Domain.Repository;
using MongoDB.Driver;

namespace Bonyan.BNB.DDD.Domain.MongoDb;

public class BnbMongoRepository<TEntity, TKey>(IMongoDatabase mongoDatabase)
    : BnbMongoReadonlyRepository<TEntity, TKey>(mongoDatabase),
        IMongoRepository<TEntity, TKey>,
        IRepository<TEntity, TKey>
    where TEntity : IBnbEntity<TKey>
{
    public async Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await Collection.InsertOneAsync(entity, cancellationToken: cancellationToken);
        return entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await Collection.ReplaceOneAsync(x=>x.Id != null && x.Id.Equals(entity.Id),entity, cancellationToken: cancellationToken);
        return entity;
    }

    public async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await Collection.DeleteOneAsync(x=>x.Id != null && x.Id.Equals(entity.Id), cancellationToken: cancellationToken);
    }

    public async Task DeleteAsync(TKey key, CancellationToken cancellationToken = default)
    {
        var entity = await GetByIdAsync(key, cancellationToken);
        await DeleteAsync(entity, cancellationToken);
    }
}