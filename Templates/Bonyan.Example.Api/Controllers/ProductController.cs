using Bonyan.BNB.AspNetCore.Mvc;
using Bonyan.BNB.DDD.Application.Dtos;
using Bonyan.Example.Application.Contracts.Products;
using Bonyan.Example.Application.Contracts.Products.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Bonyan.Example.Api.Controllers;

[Route("/api/product")]
public class ProductController : BnbCrudController<IProductAppService,ProductDto,Guid,PagedAndSortedResultRequestDto>
{
    public ProductController(IProductAppService service) : base(service)
    {
    }
}