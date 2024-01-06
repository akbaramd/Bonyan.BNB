using Bonyan.BNB.DDD.Domain;
using Bonyan.BNB.DDD.Domain.Entities;
using Bonyan.BNB.DDD.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Bonyan.BNB.EntityFrameworkCore;

public class EntEfCoreDbConfiguration<TDbContext> : DbContextOptionsBuilder where TDbContext : BnbDbContext
{
   protected IServiceCollection Services { get; set; }
   public DbContextOptionsBuilder DbContextOptionsBuilder { get; set; }

   public EntEfCoreDbConfiguration(IServiceCollection services, DbContextOptionsBuilder<TDbContext> dbContextOptionsBuilder)
   {
      Services = services;
      DbContextOptionsBuilder = dbContextOptionsBuilder;
   }

   public void AddEfRepository<TEntity, TKey>() where TEntity : class, IBnbEntity<TKey> 
   {
      Services.AddScoped(typeof(IReadOnlyRepository<TEntity,TKey>),typeof(BnbEfRepository<TDbContext,TEntity,TKey>));
      Services.AddScoped(typeof(IRepository<TEntity,TKey>),typeof(BnbEfRepository<TDbContext,TEntity,TKey>));
      Services.AddScoped(typeof(IEfReadonlyRepository<TEntity,TKey>),typeof(BnbEfRepository<TDbContext,TEntity,TKey>));
      Services.AddScoped(typeof(IReadOnlyRepository<TEntity,TKey>),typeof(BnbEfRepository<TDbContext,TEntity,TKey>));
   }

   

}