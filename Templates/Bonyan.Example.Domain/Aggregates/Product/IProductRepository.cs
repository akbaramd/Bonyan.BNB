using Bonyan.BNB.DDD.Domain.Repository;

namespace Bonyan.Example.Domain.Aggregates.Product;

public interface IProductRepository : IRepository<Product,Guid>
{
    
}