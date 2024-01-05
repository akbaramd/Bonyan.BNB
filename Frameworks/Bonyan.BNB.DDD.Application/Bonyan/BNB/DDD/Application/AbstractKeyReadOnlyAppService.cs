using Bonyan.BNB.DDD.Application.Dtos;
using Bonyan.BNB.DDD.Application.Services;
using Bonyan.BNB.DDD.Domain.Entities;
using Bonyan.BNB.DDD.Domain.Repository;

namespace Bonyan.BNB.DDD.Application;

public abstract class  AbstractKeyReadOnlyAppService<TEntity,TResultDto, TKey, TListQueryDto> : 
    AbstractKeyReadOnlyAppService<TEntity,TResultDto,TResultDto,TKey,TListQueryDto> where TEntity : IBnbEntity<TKey>
{ }

public abstract class  AbstractKeyReadOnlyAppService<TEntity,TResultDto,TResultListDto, TKey, TListQueryDto> : ApplicationService,
    IReadOnlyAppService<TResultDto,TResultListDto,TKey,TListQueryDto> where TEntity : IBnbEntity<TKey>
{


    public IReadOnlyRepository<TEntity, TKey> Repository =>
        LazyServiceProvider.LazyGetRequiredService<IReadOnlyRepository<TEntity, TKey>>();
    
    public async Task<TResultDto> GetAsync(TKey id)
    {
        var entity = await Repository.GetByIdAsync(id);
        return Mapper.Map<TEntity, TResultDto>(entity);
    }

    public async Task<PagedResultDto<TResultListDto>> GetListAsync(TListQueryDto input)
    {
        var entity = await Repository.FindAsync(x=>true);
        var count = await Repository.CountAsync(x=>true);
        var mapped = Mapper.Map<List<TEntity>, List<TResultListDto>>(entity);
        return new PagedResultDto<TResultListDto>(count,mapped.AsReadOnly());
    }
}