using Bonyan.BNB.DDD.Application.Dtos;
using Bonyan.BNB.DDD.Application.Services;
using Bonyan.BNB.DDD.Domain.Entities;
using Bonyan.BNB.DDD.Domain.Repository;

namespace Bonyan.BNB.DDD.Application;

public abstract class  AbstractKeyCrudAppService<TEntity,TResultDto, TKey> : 
    AbstractKeyCrudAppService<TEntity,TResultDto,TResultDto,TKey,PagedAndSortedResultRequestDto,TResultDto,TResultDto> where TEntity : IBnbEntity<TKey>
{

  
}

public abstract class  AbstractKeyCrudAppService<TEntity,TResultDto, TKey, TListQueryDto> : 
    AbstractKeyCrudAppService<TEntity,TResultDto,TResultDto,TKey,TListQueryDto,TResultDto,TResultDto> where TEntity : IBnbEntity<TKey>
{

  
}

public abstract class  AbstractKeyCrudAppService<TEntity,TResultDto, TKey, TListQueryDto,TCreateAndUpdateDto> : 
    AbstractKeyCrudAppService<TEntity,TResultDto,TResultDto,TKey,TListQueryDto,TCreateAndUpdateDto,TCreateAndUpdateDto> where TEntity : IBnbEntity<TKey>
{

  
}
public abstract class  AbstractKeyCrudAppService<TEntity,TResultDto,TResultListDto, TKey, TListQueryDto,TCreateAndUpdateDto> : 
    AbstractKeyCrudAppService<TEntity,TResultDto,TResultListDto,TKey,TListQueryDto,TCreateAndUpdateDto,TCreateAndUpdateDto> where TEntity : IBnbEntity<TKey>
{

  
}
public abstract class  AbstractKeyCrudAppService<TEntity,TResultDto,TResultListDto, TKey, TListQueryDto,TCreateDto,TUpdateDto> : 
    AbstractKeyReadOnlyAppService<TEntity,TResultDto,TResultListDto,TKey,TListQueryDto> ,
    ICrudAppService<TResultDto,TResultListDto,TKey,TListQueryDto,TCreateDto,TUpdateDto> where TEntity : IBnbEntity<TKey>
{

    public new IRepository<TEntity, TKey> Repository =>
        LazyServiceProvider.LazyGetRequiredService<IRepository<TEntity, TKey>>();
    
    public async Task<TResultDto> CreateAsync(TCreateDto input)
    {
        var mapToEntity = Mapper.Map<TCreateDto, TEntity>(input);
        var result = await Repository.InsertAsync(mapToEntity);
        return Mapper.Map<TEntity, TResultDto>(result);
    }

    public async Task<TResultDto> UpdateAsync(TKey id, TUpdateDto input)
    {
        var mapToEntity = Mapper.Map<TUpdateDto, TEntity>(input);
        var result = await Repository.UpdateAsync(mapToEntity);
        return Mapper.Map<TEntity, TResultDto>(result);
    }

    public async Task DeleteAsync(TKey id)
    {
    
        await Repository.DeleteAsync(id);
    }

  
}