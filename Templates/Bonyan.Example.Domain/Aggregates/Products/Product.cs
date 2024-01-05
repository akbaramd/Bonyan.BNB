using Bonyan.BNB.DDD.Domain.Entities;
using Bonyan.Example.Domain.Shared.Products;

namespace Bonyan.Example.Domain.Aggregates.Products;

public class Product : BnbEntity<Guid>
{
    public string Title { get; set; } = string.Empty;
    public string Summery { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public ProductState State { get; set; }
}