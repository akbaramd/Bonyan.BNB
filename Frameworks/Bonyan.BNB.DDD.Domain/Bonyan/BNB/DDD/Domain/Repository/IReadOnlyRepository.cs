using System.Linq.Expressions;
using Bonyan.BNB.DDD.Domain.Entities;

namespace Bonyan.BNB.DDD.Domain.Repository;

public interface IReadOnlyRepository<TEntity, in TKey> where TEntity : IBnbEntity<TKey>
{
    Task<long> CountAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default);
    Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default);
    Task<TEntity?> FindOneAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default);
    Task<TEntity> GetOneAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default);
    Task<TEntity?> FindByIdAsync(TKey key, CancellationToken cancellationToken = default);
    Task<TEntity> GetByIdAsync(TKey key, CancellationToken cancellationToken = default);
    Task<IQueryable<TEntity>> GetQueryableAsync( CancellationToken cancellationToken = default) ;
}