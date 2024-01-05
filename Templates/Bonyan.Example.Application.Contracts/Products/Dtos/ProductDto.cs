using Bonyan.BNB.DDD.Application.Dtos;
using Bonyan.Example.Domain.Shared.Products;

namespace Bonyan.Example.Application.Contracts.Products.Dtos;

public class ProductDto : EntityDto<Guid>
{
    public string Title { get; set; } = string.Empty;
    public string Summery { get; set; } = string.Empty;
    public string Price { get; set; }
    public ProductState State { get; set; }
}