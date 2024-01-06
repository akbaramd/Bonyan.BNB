using Bonyan.BNB.DDD.Domain.Entities;
using Bonyan.BNB.DDD.Domain.Repository;
using Bonyan.BNB.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bonyan.BNB.DDD.Domain;

public class BnbEfRepository<TDbContext,TEntity, TKey>
    : BnbEfReadonlyRepository<TDbContext,TEntity,TKey>,
        IEfRepository<TEntity, TKey>,
        IRepository<TEntity, TKey>
    where TEntity :class, IBnbEntity<TKey> 
    where TDbContext : BnbDbContext
{
    
    public BnbEfRepository(DbContext dbContext) : base(dbContext)
    {
    }
    
    public async Task<TEntity> InsertAsync(TEntity entity,bool autoSave = true, CancellationToken cancellationToken = default)
    {
       var res =  await DbContext.Set<TEntity>().AddAsync(entity, cancellationToken: cancellationToken);
       if (autoSave)
       {
           await DbContext.SaveChangesAsync(cancellationToken);
       }
       return res.Entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity,bool autoSave = true, CancellationToken cancellationToken = default)
    {
        var res =   DbContext.Set<TEntity>().Update(entity);
        if (autoSave)
        {
            await DbContext.SaveChangesAsync(cancellationToken);
        }
        return res.Entity;
    }

    public async Task DeleteAsync(TEntity entity,bool autoSave = true, CancellationToken cancellationToken = default)
    {
        DbContext.Set<TEntity>().Remove(entity);
        
        if (autoSave)
        {
            await DbContext.SaveChangesAsync(cancellationToken);
        }
    }

    public async Task DeleteAsync(TKey key,bool autoSave = true, CancellationToken cancellationToken = default)
    {
        var entity = await GetByIdAsync(key, cancellationToken);
        await DeleteAsync(entity, autoSave,cancellationToken);
    }

  
}