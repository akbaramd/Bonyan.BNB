using Bonyan.BNB.DDD.Application.Dtos;
using Bonyan.Example.Application.Contracts.Products;
using Bonyan.Example.Application.Contracts.Products.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Bonyan.Example.Api.Controllers;

[Route("/api/product")]
public class ProductController : ControllerBase
{
    private readonly IProductAppService _appService;

    public ProductController(IProductAppService appService)
    {
        _appService = appService;
    }


    [HttpGet]
    // GET
    public async Task<PagedResultDto<ProductDto>> Get([FromQuery] PagedAndSortedResultRequestDto requestDto)
    {
        return await _appService.GetListAsync(requestDto);
    }
    
    
    [HttpPost]
    public async Task<ProductDto> Create([FromBody] ProductDto createDto)
    {
        return await _appService.CreateAsync(createDto);
    }
    
    [HttpGet("{id}")]
    public async Task<ProductDto> Get(Guid id)
    {
        return await _appService.GetAsync(id);
    }
    
    [HttpPut("{id}")]
    public async Task<ProductDto> Put(Guid id,[FromBody] ProductDto dto)
    {
        return await _appService.UpdateAsync(id,dto);
    }
    [HttpDelete("{id}")]
    public async Task Delete(Guid id)
    {
         await _appService.DeleteAsync(id);
    }
}