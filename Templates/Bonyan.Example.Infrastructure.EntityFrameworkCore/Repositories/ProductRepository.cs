using Bonyan.BNB.DDD.Domain;
using Bonyan.Example.Domain.Aggregates.Products;

namespace Bonyan.Example.Infrastructure.EntityFrameworkCore.Repositories;

public class ProductRepository(AppDbContext dbContext) : BnbEfRepository<AppDbContext,Product,Guid>(dbContext), IProductRepository
{
    
}