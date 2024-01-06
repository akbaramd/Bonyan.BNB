using Bonyan.BNB.DDD.Application.Dtos;
using Bonyan.BNB.DDD.Domain.Entities;
using Bonyan.Bnb.DependencyInjection;

namespace Bonyan.BNB.DDD.Application;

public class CrudAppService<TEntity,TResultDto, TKey> :
    CrudAppService<TEntity, TResultDto, TKey,PagedAndSortedResultRequestDto> 
    where TEntity : IBnbEntity<TKey>
    where TResultDto : IEntityDto<TKey>
{
    public CrudAppService(IBnbLazyServiceProvider lazyServiceProvider) : base(lazyServiceProvider)
    {
    }


   
}

public class CrudAppService<TEntity,TResultDto, TKey, TListQueryDto> :
    CrudAppService<TEntity, TResultDto,TResultDto, TKey,TListQueryDto,TResultDto> 
    where TEntity : IBnbEntity<TKey>
    where TResultDto : IEntityDto<TKey>
{
    public CrudAppService(IBnbLazyServiceProvider lazyServiceProvider) : base(lazyServiceProvider)
    {
    }
}
public class CrudAppService<TEntity,TResultDto,TResultListDto, TKey, TListQueryDto,TCreateAndUpdateDto> :
    CrudAppService<TEntity, TResultDto,TResultListDto, TKey,TListQueryDto,TCreateAndUpdateDto,TCreateAndUpdateDto> 
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
    
    protected override Task<TEntity> GetEntityByIdAsync(TKey id)
    {
        return Repository.GetByIdAsync(id);
    }
}