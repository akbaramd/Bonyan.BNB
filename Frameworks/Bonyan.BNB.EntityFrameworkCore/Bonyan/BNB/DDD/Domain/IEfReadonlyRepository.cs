using Bonyan.BNB.DDD.Domain.Entities;
using Bonyan.BNB.DDD.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Bonyan.BNB.DDD.Domain;

public interface IEfReadonlyRepository<TEntity, in TKey> : IReadOnlyRepository<TEntity,TKey> where TEntity : IBnbEntity<TKey>
{

}