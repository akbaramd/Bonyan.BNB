using System.Linq.Expressions;
using Bonyan.BNB.Domain.Entities;

namespace Bonyan.BNB.DDD.Domain.Repository;

public interface IRepository<TEntity, in TKey> : IReadonlyRepository<TEntity,TKey> where TEntity : IBnbEntity<TKey>
{
    Task InsertAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);
}