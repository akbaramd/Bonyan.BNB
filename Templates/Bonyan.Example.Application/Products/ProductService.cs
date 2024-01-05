using Bonyan.BNB.DDD.Application;
using Bonyan.BNB.DDD.Application.Dtos;
using Bonyan.Bnb.DependencyInjection;
using Bonyan.Example.Application.Contracts.Products;
using Bonyan.Example.Application.Contracts.Products.Dtos;
using Bonyan.Example.Domain.Aggregates.Products;

namespace Bonyan.Example.Application.Products;

[ExposeServices(typeof(IProductAppService))]
public class ProductService : 
    CrudAppService<Product,ProductDto,Guid,PagedAndSortedResultRequestDto>,IProductAppService
{
    public ProductService(IBnbLazyServiceProvider lazyServiceProvider) : base(lazyServiceProvider)
    {
    }
}