using Bonyan.BNB.DDD.Application.Dtos;
using Bonyan.BNB.DDD.Application.Services;
using Bonyan.Bnb.DependencyInjection;
using Bonyan.BNB.Identity.Application.Contracts.Users.Dtos;
using Bonyan.BNB.Identity.Domain.Users;

namespace Bonyan.BNB.Identity.Application.Contracts.Users;

public interface IUserAppService: ICrudAppService<UserDto,UserDto,Guid,PagedAndSortedResultRequestDto,UserCreateDto,UserUpdateDto>,ITransientDependency
{
    public Task<UserDto> GetByUserNameAsync(string userName);
    public Task<UserDto> GetByEmailAsync(string email);
    public Task<UserDto> GetByMobileNumberAsync(string mobileNumber);
    
    public Task<UserDto?> FindByUserNameAsync(string userName);
    public Task<UserDto?> FindByEmailAsync(string email);
    public Task<UserDto?> FindByMobileNumberAsync(string mobileNumber);
}