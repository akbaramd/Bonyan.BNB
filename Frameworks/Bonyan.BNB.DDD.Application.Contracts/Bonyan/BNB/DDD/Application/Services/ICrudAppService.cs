using Bonyan.BNB.DDD.Application.Dtos;

namespace Bonyan.BNB.DDD.Application.Services;


public interface ICrudAppService<TResultDto,in TKey>
    : ICrudAppService<TResultDto, TKey,  PagedAndSortedResultRequestDto, TResultDto>
{

}
public interface ICrudAppService<TResultDto,in TKey, in TListQueryDto>
    : ICrudAppService<TResultDto, TKey,  TListQueryDto, TResultDto>
{

}

public interface ICrudAppService<TResultDto,in TKey, in TListQueryDto, in TCreateAndUpdateDto>
    : ICrudAppService<TResultDto,TResultDto, TKey,  TListQueryDto, TCreateAndUpdateDto>
{

}
public interface ICrudAppService< TResultDto, TListResultDto,in TKey, in TListQueryDto, in TCreateAndUpdateDto>
    : ICrudAppService<TResultDto,TListResultDto, TKey,  TListQueryDto, TCreateAndUpdateDto, TCreateAndUpdateDto>
{

}

public interface ICrudAppService< TResultDto, TListResultDto,in TKey, in TListQueryDto, in TCreateDto, in TUpdateDto>
    : IReadOnlyAppService<TResultDto, TListResultDto, TKey, TListQueryDto>,
        ICreateUpdateAppService<TResultDto, TKey, TCreateDto, TUpdateDto>,
        IDeleteAppService<TKey>
{

}
