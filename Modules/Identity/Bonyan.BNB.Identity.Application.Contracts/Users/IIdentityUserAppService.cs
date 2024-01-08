using Bonyan.BNB.DDD.Application.Dtos;
using Bonyan.BNB.DDD.Application.Services;
using Bonyan.Bnb.DependencyInjection;
using Bonyan.BNB.Identity.Application.Contracts.Users.Dtos;

namespace Bonyan.BNB.Identity.Application.Contracts.Users;

public interface IIdentityUserAppService: ICrudAppService<IdentityUserDto,IdentityUserDto,Guid,PagedAndSortedResultRequestDto,IdentityUserCreateDto,IdentityUserUpdateDto>,ITransientDependency
{
    public Task<IdentityUserDto> GetByUserNameAsync(string userName);
    public Task<IdentityUserDto> GetByEmailAsync(string email);
    public Task<IdentityUserDto> GetByMobileNumberAsync(string mobileNumber);
    
    public Task<IdentityUserDto?> FindByUserNameAsync(string userName);
    public Task<IdentityUserDto?> FindByEmailAsync(string email);
    public Task<IdentityUserDto?> FindByMobileNumberAsync(string mobileNumber);
}