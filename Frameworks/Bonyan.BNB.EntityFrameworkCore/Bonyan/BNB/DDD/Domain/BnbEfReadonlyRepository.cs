using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Reflection;
using Bonyan.BNB.DDD.Domain.Entities;
using Bonyan.BNB.DDD.Domain.Repository;
using Bonyan.BNB.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bonyan.BNB.DDD.Domain;

public class BnbEfReadonlyRepository<TDbContext,TEntity,TKey> :
    IReadOnlyRepository<TEntity,TKey>,
    IEfReadonlyRepository<TEntity,TKey> 
    where TDbContext : BnbDbContext
    where TEntity : class, IBnbEntity<TKey>
{
    public BnbEfReadonlyRepository(DbContext dbContext)
    {
        DbContext = dbContext;
    }

    public DbContext DbContext { get; set; }
    
    public async Task<long> CountAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default)
    {
        var find = await DbContext.Set<TEntity>().CountAsync(filter, cancellationToken: cancellationToken);
        return find;
    }

    public async Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default)
    {
        var find =  DbContext.Set<TEntity>().Where(filter);
        return await find.ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<TEntity?> FindOneAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default)
    {
        var find = await DbContext.Set<TEntity>().FirstOrDefaultAsync(filter, cancellationToken: cancellationToken);
        return find;
    }

    public async Task<TEntity> GetOneAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default)
    {
        var find = await DbContext.Set<TEntity>().FirstAsync(filter, cancellationToken: cancellationToken);
        return find;
    }

    public async Task<TEntity?> FindByIdAsync(TKey key, CancellationToken cancellationToken = default)
    {
        var find = await DbContext.Set<TEntity>().FirstOrDefaultAsync(x=>x.Id.Equals(key), cancellationToken: cancellationToken);
        return find;
    }

    public async Task<TEntity> GetByIdAsync(TKey key, CancellationToken cancellationToken = default)
    {
        var find = await DbContext.Set<TEntity>().FirstAsync(x=>x.Id.Equals(key), cancellationToken: cancellationToken);
        return find;
    }


    public Task<IQueryable<TEntity>> GetQueryableAsync(CancellationToken cancellationToken = default) 
    {
     return Task.FromResult<IQueryable<TEntity>>(DbContext.Set<TEntity>());

    }
}