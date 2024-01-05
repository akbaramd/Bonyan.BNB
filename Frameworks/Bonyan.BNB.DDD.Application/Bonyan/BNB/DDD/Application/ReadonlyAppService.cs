using Bonyan.BNB.DDD.Application.Dtos;
using Bonyan.BNB.DDD.Domain.Entities;

namespace Bonyan.BNB.DDD.Application;


public class ReadonlyAppService<TEntity,TResultDto, TKey, TListQueryDto> :
    AbstractKeyReadOnlyAppService<TEntity,TResultDto,TKey,TListQueryDto> 
    where TEntity : IBnbEntity<TKey> 
    where TResultDto : IEntityDto<TKey>
{
}

public class ReadonlyAppService<TEntity,TResultDto,TResultListDto, TKey, TListQueryDto> :
    AbstractKeyReadOnlyAppService<TEntity,TResultDto,TResultListDto,TKey,TListQueryDto> 
    where TEntity : IBnbEntity<TKey> 
    where TResultDto : IEntityDto<TKey>
    where TResultListDto : IEntityDto<TKey>
{
    
    
}