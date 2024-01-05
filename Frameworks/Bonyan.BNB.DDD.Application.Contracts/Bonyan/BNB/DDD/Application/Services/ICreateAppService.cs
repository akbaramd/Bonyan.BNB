namespace Bonyan.BNB.DDD.Application.Services;

public interface ICreateAppService<TEntityDto>
    : ICreateAppService<TEntityDto, TEntityDto>
{

}

public interface ICreateAppService<TCreateResultDto, in TCreateInputDto>
    : IApplicationService
{
    Task<TCreateResultDto> CreateAsync(TCreateInputDto input);
}
