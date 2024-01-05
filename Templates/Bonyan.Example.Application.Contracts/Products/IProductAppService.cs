using Bonyan.BNB.DDD.Application.Dtos;
using Bonyan.BNB.DDD.Application.Services;
using Bonyan.Bnb.DependencyInjection;
using Bonyan.Example.Application.Contracts.Products.Dtos;

namespace Bonyan.Example.Application.Contracts.Products;

public interface IProductAppService : ICrudAppService<ProductDto,Guid,PagedAndSortedResultRequestDto>,ITransientDependency
{
    
}