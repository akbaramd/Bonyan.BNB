using System.Linq.Dynamic.Core;
using Bonyan.BNB.Auditing;
using Bonyan.BNB.DDD.Application.Dtos;
using Bonyan.BNB.DDD.Application.Services;
using Bonyan.BNB.DDD.Domain.Entities;
using Bonyan.BNB.DDD.Domain.Repository;
using Bonyan.Bnb.DependencyInjection;
using Bonyan.Bnb.Extensions;

namespace Bonyan.BNB.DDD.Application;

public abstract class  AbstractKeyReadOnlyAppService<TEntity,TResultDto, TKey, TListQueryDto> : 
    AbstractKeyReadOnlyAppService<TEntity,TResultDto,TResultDto,TKey,TListQueryDto> where TEntity : IBnbEntity<TKey>
{
    protected AbstractKeyReadOnlyAppService(IBnbLazyServiceProvider lazyServiceProvider) : base(lazyServiceProvider)
    {
    }
}

public abstract class  AbstractKeyReadOnlyAppService<TEntity,TResultDto,TResultListDto, TKey, TListQueryDto> : ApplicationService,
    IReadOnlyAppService<TResultDto,TResultListDto,TKey,TListQueryDto> where TEntity : IBnbEntity<TKey>
{

    public IReadOnlyRepository<TEntity, TKey> Repository =>
        LazyServiceProvider.LazyGetRequiredService<IReadOnlyRepository<TEntity, TKey>>();
    
    protected abstract Task<TEntity> GetEntityByIdAsync(TKey id);
    
    public async Task<TResultDto> GetAsync(TKey id)
    {

        var entity = await GetEntityByIdAsync(id);

        return await MapToGetOutputDtoAsync(entity);
    }

    public async Task<PagedResultDto<TResultListDto>> GetListAsync(TListQueryDto input)
    {

        var query = await CreateFilteredQueryAsync(input);
        var totalCount = await AsyncQueryableExecuter.CountAsync(query);

        var entities = new List<TEntity>();
        var entityDtos = new List<TResultListDto>();

        if (totalCount > 0)
        {
            query = ApplySorting(query, input);
            query = ApplyPaging(query, input);

            entities = await AsyncQueryableExecuter.ToListAsync(query);
            entityDtos = await MapToGetListOutputDtosAsync(entities);
        }

        return new PagedResultDto<TResultListDto>(
            totalCount,
            entityDtos
        );
    }

    protected AbstractKeyReadOnlyAppService(IBnbLazyServiceProvider lazyServiceProvider) : base(lazyServiceProvider)
    {
    }
    
    
     protected virtual IQueryable<TEntity> ApplySorting(IQueryable<TEntity> query, TListQueryDto input)
    {
        //Try to sort query if available
        if (input is ISortedResultRequest sortInput)
        {
            if (!sortInput.Sort.IsNullOrWhiteSpace())
            {
                    return query.OrderBy(sortInput.Sort!);
            }
        }

        //IQueryable.Task requires sorting, so we should sort if Take will be used.
        if (input is ILimitedResultRequest)
        {
            return ApplyDefaultSorting(query);
        }

        //No sorting
        return query;
    }

    /// <summary>
    /// Applies sorting if no sorting specified but a limited result requested.
    /// </summary>
    /// <param name="query">The query.</param>
    protected virtual IQueryable<TEntity> ApplyDefaultSorting(IQueryable<TEntity> query)
    {
        if (typeof(TEntity).IsAssignableTo<IHasCreationTime>())
        {
            return query.OrderByDescending(e => ((IHasCreationTime)e).CreationTime);
        }

        throw new Exception("No sorting specified but this query requires sorting. Override the ApplySorting or the ApplyDefaultSorting method for your application service derived from AbstractKeyReadOnlyAppService!");
    }

    /// <summary>
    /// Should apply paging if needed.
    /// </summary>
    /// <param name="query">The query.</param>
    /// <param name="input">The input.</param>
    protected virtual IQueryable<TEntity> ApplyPaging(IQueryable<TEntity> query, TListQueryDto input)
    {
        //Try to use paging if available
        if (input is IPagedResultRequest pagedInput)
        {
            return query.PageBy(pagedInput);
        }

        //Try to limit query result if available
        if (input is ILimitedResultRequest limitedInput)
        {
            return query.Take(limitedInput.Take);
        }

        //No paging
        return query;
    }

    /// <summary>
    /// This method should create <see cref="IQueryable{TEntity}"/> based on given input.
    /// It should filter query if needed, but should not do sorting or paging.
    /// Sorting should be done in <see cref="ApplySorting"/> and paging should be done in <see cref="ApplyPaging"/>
    /// methods.
    /// </summary>
    /// <param name="input">The input.</param>
    protected virtual async Task<IQueryable<TEntity>> CreateFilteredQueryAsync(TListQueryDto input)
    {
        return await Repository.GetQueryableAsync();
    }

    /// <summary>
    /// Maps <typeparamref name="TEntity"/> to <typeparamref name="TGetOutputDto"/>.
    /// It internally calls the <see cref="MapToGetOutputDto"/> by default.
    /// It can be overriden for custom mapping.
    /// Overriding this has higher priority than overriding the <see cref="MapToGetOutputDto"/>
    /// </summary>
    protected virtual Task<TResultDto> MapToGetOutputDtoAsync(TEntity entity)
    {
        return Task.FromResult(MapToGetOutputDto(entity));
    }

    /// <summary>
    /// Maps <typeparamref name="TEntity"/> to <typeparamref name="TGetOutputDto"/>.
    /// It uses <see cref="IObjectMapper"/> by default.
    /// It can be overriden for custom mapping.
    /// </summary>
    protected virtual TResultDto MapToGetOutputDto(TEntity entity)
    {
        return Mapper.Map<TEntity, TResultDto>(entity);
    }

    /// <summary>
    /// Maps a list of <typeparamref name="TEntity"/> to <typeparamref name="TGetListOutputDto"/> objects.
    /// It uses <see cref="MapToGetListOutputDtoAsync"/> method for each item in the list.
    /// </summary>
    protected virtual async Task<List<TResultListDto>> MapToGetListOutputDtosAsync(List<TEntity> entities)
    {
        var dtos = new List<TResultListDto>();

        foreach (var entity in entities)
        {
            dtos.Add(await MapToGetListOutputDtoAsync(entity));
        }

        return dtos;
    }

    /// <summary>
    /// Maps <typeparamref name="TEntity"/> to <typeparamref name="TGetListOutputDto"/>.
    /// It internally calls the <see cref="MapToGetListOutputDto"/> by default.
    /// It can be overriden for custom mapping.
    /// Overriding this has higher priority than overriding the <see cref="MapToGetListOutputDto"/>
    /// </summary>
    protected virtual Task<TResultListDto> MapToGetListOutputDtoAsync(TEntity entity)
    {
        return Task.FromResult(MapToGetListOutputDto(entity));
    }

    /// <summary>
    /// Maps <typeparamref name="TEntity"/> to <typeparamref name="TGetListOutputDto"/>.
    /// It uses <see cref="IObjectMapper"/> by default.
    /// It can be overriden for custom mapping.
    /// </summary>
    protected virtual TResultListDto MapToGetListOutputDto(TEntity entity)
    {
        return Mapper.Map<TEntity, TResultListDto>(entity);
    }
}