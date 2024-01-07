using Bonyan.BNB.DDD.Domain.Entities;

namespace Bonyan.BNB.DDD.Domain.Repository;

public interface IRepository<TEntity, in TKey> : IReadOnlyRepository<TEntity,TKey> where TEntity : IBnbEntity<TKey>
{
    Task<TEntity> InsertAsync(TEntity entity,bool autoSave = true, CancellationToken cancellationToken = default);
    Task<TEntity> UpdateAsync(TEntity entity,bool autoSave = true, CancellationToken cancellationToken = default);
    Task DeleteAsync(TEntity entity,bool autoSave = true, CancellationToken cancellationToken = default);
    Task DeleteAsync(TKey key,bool autoSave = true, CancellationToken cancellationToken = default);
}