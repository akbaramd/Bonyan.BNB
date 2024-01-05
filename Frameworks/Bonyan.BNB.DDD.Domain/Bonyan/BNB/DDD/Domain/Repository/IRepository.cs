using System.Linq.Expressions;
using Bonyan.BNB.DDD.Domain.Entities;

namespace Bonyan.BNB.DDD.Domain.Repository;

public interface IRepository<TEntity, in TKey> : IReadOnlyRepository<TEntity,TKey> where TEntity : IBnbEntity<TKey>
{
    Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(TKey key, CancellationToken cancellationToken = default);
}