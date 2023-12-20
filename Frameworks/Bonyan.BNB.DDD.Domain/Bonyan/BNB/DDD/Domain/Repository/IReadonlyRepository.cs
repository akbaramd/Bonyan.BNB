using System.Linq.Expressions;
using Bonyan.BNB.Domain.Entities;

namespace Bonyan.BNB.DDD.Domain.Repository;

public interface IReadonlyRepository<TEntity, in TKey> where TEntity : IBnbEntity<TKey>
{
    Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default);
    Task<TEntity?> FindOneAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default);
    Task<TEntity> GetOneAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default);
    Task<TEntity?> FindByIdAsync(TKey key, CancellationToken cancellationToken = default);
    Task<TEntity> GetByIdAsync(TKey key, CancellationToken cancellationToken = default);
}