using Bonyan.BNB.DDD.Application.Dtos;
using Bonyan.BNB.DDD.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bonyan.BNB.AspNetCore.Mvc;

public class
    BnbCrudController<TService, TResultDto, TKey> 
    : BnbCrudController<TService, TResultDto, TKey, PagedAndSortedResultRequestDto> 
    where TService 
    :
    ICrudAppService<TResultDto, TResultDto, TKey, PagedAndSortedResultRequestDto, TResultDto, TResultDto>
{
    public BnbCrudController(TService service) : base(service)
    {
    }
}

public class
    BnbCrudController<TService, TResultDto, TKey, TListQueryDto> 
    : BnbCrudController<TService, TResultDto, TKey, TListQueryDto, TResultDto> 
    where TService 
    : 
    ICrudAppService<TResultDto, TResultDto, TKey, TListQueryDto, TResultDto, TResultDto>
{
    public BnbCrudController(TService service) : base(service)
    {
    }
}
public class
    BnbCrudController<TService, TResultDto, TKey, TListQueryDto, TCreateAndUpdateDto> 
    : BnbCrudController<TService, TResultDto, TKey, TListQueryDto, TCreateAndUpdateDto, TCreateAndUpdateDto>  
    where TService 
    :
    ICrudAppService<TResultDto, TResultDto, TKey, TListQueryDto, TCreateAndUpdateDto, TCreateAndUpdateDto>
{
    public BnbCrudController(TService service) : base(service)
    {
    }
}

public class
    BnbCrudController<TService, TResultDto, TKey, TListQueryDto, TCreateDto, TUpdateDto> 
    : BnbCrudController<TService,TResultDto,TResultDto,TKey,TListQueryDto,TCreateDto,TUpdateDto> 
    where TService 
    :
    ICrudAppService<TResultDto, TResultDto, TKey, TListQueryDto, TCreateDto, TUpdateDto>
{
    public BnbCrudController(TService service) : base(service)
    {
    }
}

public class BnbCrudController<TService,TResultDto, TListResultDto, TKey,  TListQueryDto,  TCreateDto,  TUpdateDto>
    : ControllerBase 
    where TService : ICrudAppService<TResultDto, TListResultDto, TKey,  TListQueryDto,  TCreateDto,  TUpdateDto>
{
    public  TService AppService { get; set; } = default!;

    public BnbCrudController(TService service)
    {
        AppService = service;
    }


    [HttpGet]
    // GET
    public async Task<PagedResultDto<TListResultDto>> Get([FromQuery]  TListQueryDto requestDto)
    {
        return await AppService.GetListAsync(requestDto);
    }
    
    
    [HttpPost]
    public async Task<TResultDto> Create([FromBody] TCreateDto createDto)
    {
        return await AppService.CreateAsync(createDto);
    }
    
    [HttpGet("{id}")]
    public async Task<TResultDto> Get(TKey id)
    {
        return await AppService.GetAsync(id);
    }
    
    [HttpPut("{id}")]
    public async Task<TResultDto> Put(TKey id,[FromBody] TUpdateDto dto)
    {
        return await AppService.UpdateAsync(id,dto);
    }
    [HttpDelete("{id}")]
    public async Task Delete(TKey id)
    {
        await AppService.DeleteAsync(id);
    }
}