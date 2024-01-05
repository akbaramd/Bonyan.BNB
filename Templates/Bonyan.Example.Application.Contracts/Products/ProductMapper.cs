using AutoMapper;
using Bonyan.Example.Application.Contracts.Products.Dtos;
using Bonyan.Example.Domain.Aggregates.Products;

namespace Bonyan.Example.Application.Contracts.Products;

public class ProductMapper : Profile
{
    public ProductMapper()
    {
        CreateMap<Product, ProductDto>().ReverseMap();
    }
}