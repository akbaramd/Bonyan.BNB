using Bonyan.BNB.DDD.Application.Dtos;
using Bonyan.BNB.DDD.Domain.Entities;
using Bonyan.Bnb.DependencyInjection;

namespace Bonyan.BNB.DDD.Application;

public class CrudAppService<TEntity,TResultDto, TKey> :
    AbstractKeyCrudAppService<TEntity, TResultDto, TKey> 
    where TEntity : IBnbEntity<TKey>
    where TResultDto : IEntityDto<TKey>
{
    public CrudAppService(IBnbLazyServiceProvider lazyServiceProvider) : base(lazyServiceProvider)
    {
    }
}

public class CrudAppService<TEntity,TResultDto, TKey, TListQueryDto> :
    AbstractKeyCrudAppService<TEntity, TResultDto, TKey,TListQueryDto> 
    where TEntity : IBnbEntity<TKey>
    where TResultDto : IEntityDto<TKey>
{
    public CrudAppService(IBnbLazyServiceProvider lazyServiceProvider) : base(lazyServiceProvider)
    {
    }
}
public class CrudAppService<TEntity,TResultDto,TResultListDto, TKey, TListQueryDto,TCreateAndUpdateDto> :
    AbstractKeyCrudAppService<TEntity, TResultDto,TResultListDto, TKey,TListQueryDto,TCreateAndUpdateDto> 
    where TEntity : IBnbEntity<TKey>
    where TResultDto : IEntityDto<TKey>
    where TResultListDto : IEntityDto<TKey>
{
    public CrudAppService(IBnbLazyServiceProvider lazyServiceProvider) : base(lazyServiceProvider)
    {
    }
}
public class CrudAppService<TEntity,TResultDto,TResultListDto, TKey, TListQueryDto,TCreateDto,TUpdateDto> :
    AbstractKeyCrudAppService<TEntity, TResultDto,TResultListDto, TKey,TListQueryDto,TCreateDto,   TUpdateDto> 
    where TEntity : IBnbEntity<TKey>
    where TResultDto : IEntityDto<TKey>
    where TResultListDto : IEntityDto<TKey>
{
    public CrudAppService(IBnbLazyServiceProvider lazyServiceProvider) : base(lazyServiceProvider)
    {
    }
}