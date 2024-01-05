
using Bonyan.BNB.DDD.Application.Dtos;

namespace Bonyan.BNB.DDD.Application.Services;


public interface IReadOnlyAppService<TEntityDtoDto, TListDto, in TKey, in TListQueryDto>
    : IApplicationService
{
    Task<TEntityDtoDto> GetAsync(TKey id);

    Task<PagedResultDto<TListDto>> GetListAsync(TListQueryDto input);
    
}

public interface IReadOnlyAppService<TEntityDtoDto, in TKey, in TListQueryDto>
    : IReadOnlyAppService<TEntityDtoDto,TEntityDtoDto,TKey,TListQueryDto>
{
}