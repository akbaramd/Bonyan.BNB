namespace Bonyan.BNB.DDD.Application.Services;


public interface IUpdateAppService<TResultDto, in TKey, in TInputDto>
    : IApplicationService
{
    Task<TResultDto> UpdateAsync(TKey id, TInputDto input);
}
