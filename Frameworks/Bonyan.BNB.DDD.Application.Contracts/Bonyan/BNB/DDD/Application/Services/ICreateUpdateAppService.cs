namespace Bonyan.BNB.DDD.Application.Services;

public interface ICreateUpdateAppService<TDto, in TKey>
    : ICreateUpdateAppService<TDto, TKey, TDto, TDto>
{

}

public interface ICreateUpdateAppService<TResultDto, in TKey, in TCreateAndUpdateDto>
    : ICreateUpdateAppService<TResultDto, TKey, TCreateAndUpdateDto, TCreateAndUpdateDto>
{

}

public interface ICreateUpdateAppService<TResultDto, in TKey, in TCreateDto, in TUpdateDto>
    : ICreateAppService<TResultDto, TCreateDto>,
        IUpdateAppService<TResultDto, TKey, TUpdateDto>
{

}
