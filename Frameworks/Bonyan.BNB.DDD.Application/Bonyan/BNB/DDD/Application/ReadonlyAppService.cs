using Bonyan.BNB.DDD.Application.Dtos;
using Bonyan.BNB.DDD.Domain.Entities;
using Bonyan.Bnb.DependencyInjection;

namespace Bonyan.BNB.DDD.Application;


public class ReadonlyAppService<TEntity,TResultDto, TKey, TListQueryDto> :
    ReadonlyAppService<TEntity,TResultDto,TResultDto,TKey,TListQueryDto> 
    where TEntity : IBnbEntity<TKey> 
    where TResultDto : IEntityDto<TKey>
{
    public ReadonlyAppService(IBnbLazyServiceProvider lazyServiceProvider) : base(lazyServiceProvider)
    {
    }

  
}

public class ReadonlyAppService<TEntity,TResultDto,TResultListDto, TKey, TListQueryDto> :
    AbstractKeyReadOnlyAppService<TEntity,TResultDto,TResultListDto,TKey,TListQueryDto> 
    where TEntity : IBnbEntity<TKey> 
    where TResultDto : IEntityDto<TKey>
    where TResultListDto : IEntityDto<TKey>
{
    public ReadonlyAppService(IBnbLazyServiceProvider lazyServiceProvider) : base(lazyServiceProvider)
    {
    }

    protected override Task<TEntity> GetEntityByIdAsync(TKey id)
    {
        return Repository.GetByIdAsync(id);
    }
}