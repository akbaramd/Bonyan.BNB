using Bonyan.BNB.DDD.Domain.Repository;

namespace Bonyan.Example.Domain.Aggregates.Products;

public interface IProductRepository : IRepository<Product,Guid>
{
    
}