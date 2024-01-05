using System.Linq.Expressions;
using System.Reflection;
using Bonyan.BNB.DDD.Domain.Entities;
using Bonyan.BNB.DDD.Domain.Repository;
using Bonyan.BNB.MongoDb.Attributes;
using MongoDB.Driver;

namespace Bonyan.BNB.DDD.Domain.MongoDb;

public class BnbMongoReadonlyRepository<TEntity,TKey> :
    IReadOnlyRepository<TEntity,TKey>,
    IMongoReadonlyRepository<TEntity,TKey> where TEntity : IBnbEntity<TKey>
{
    public  IMongoCollection<TEntity> Collection { get; set; }

    public BnbMongoReadonlyRepository(IMongoDatabase mongoDatabase)
    {
        var collectionName = typeof(TEntity).GetCustomAttribute<CollectionAttribute>();
        Collection =
            mongoDatabase.GetCollection<TEntity>(collectionName is null ? typeof(TEntity).Name : collectionName.Name);
    }

    public async Task<long> CountAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default)
    {
        var find = await Collection.CountDocumentsAsync(filter, cancellationToken: cancellationToken);
        return find;
    }

    public async Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default)
    {
        var find = await Collection.FindAsync(filter, cancellationToken: cancellationToken);
        return await find.ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<TEntity?> FindOneAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default)
    {
        var find = await Collection.FindAsync(filter, cancellationToken: cancellationToken);
        return await find.FirstOrDefaultAsync(cancellationToken: cancellationToken);
    }

    public async Task<TEntity> GetOneAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default)
    {
        var find = await Collection.FindAsync(filter, cancellationToken: cancellationToken);
        return await find.FirstAsync(cancellationToken: cancellationToken);
    }

    public async Task<TEntity?> FindByIdAsync(TKey key, CancellationToken cancellationToken = default)
    {
        var find = await Collection.FindAsync(x=>x.Id != null && x.Id.Equals(key), cancellationToken: cancellationToken);
        return await find.FirstOrDefaultAsync(cancellationToken: cancellationToken);
    }

    public async Task<TEntity> GetByIdAsync(TKey key, CancellationToken cancellationToken = default)
    {
        var find = await Collection.FindAsync(x=>x.Id != null && x.Id.Equals(key), cancellationToken: cancellationToken);
        return await find.FirstAsync(cancellationToken: cancellationToken);
    }

    public Task<IQueryable<TEntity1>> GetQueryableAsync<TEntity1>(CancellationToken cancellationToken = default) where TEntity1 : class, IBnbEntity
    {
        throw new NotImplementedException();
    }

    public Task<IQueryable<TEntity>> GetQueryableAsync(CancellationToken cancellationToken = default) 
    {
     return Task.FromResult<IQueryable<TEntity>>(Collection.AsQueryable());

    }
}