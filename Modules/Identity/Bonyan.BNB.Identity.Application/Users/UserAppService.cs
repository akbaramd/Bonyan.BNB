using Bonyan.BNB.DDD.Application;
using Bonyan.BNB.DDD.Application.Dtos;
using Bonyan.Bnb.DependencyInjection;
using Bonyan.BNB.Identity.Application.Contracts.Users;
using Bonyan.BNB.Identity.Application.Contracts.Users.Dtos;
using Bonyan.BNB.Identity.Domain.Users;

namespace Bonyan.BNB.Identity.Application.Users;

public class UserAppService : CrudAppService<User,UserDto,UserDto,Guid,PagedAndSortedResultRequestDto,UserCreateDto,UserUpdateDto> ,IUserAppService
{
    public UserAppService(IBnbLazyServiceProvider lazyServiceProvider) : base(lazyServiceProvider)
    {
    }
    
    public async Task<UserDto> GetByUserNameAsync(string userName)
    {
        var find = await Repository.GetOneAsync(x => x.UserName.Equals(userName));
        return Mapper.Map<User, UserDto>(find);
    }

    public async Task<UserDto> GetByEmailAsync(string email)
    {
        var find = await Repository.GetOneAsync(x => x.Email.Equals(email));
        return Mapper.Map<User, UserDto>(find);
    }

    public async Task<UserDto> GetByMobileNumberAsync(string mobileNumber)
    {
        var find = await Repository.GetOneAsync(x => x.MobileNumber.Equals(mobileNumber));
        return Mapper.Map<User, UserDto>(find);
    }

    public async Task<UserDto?> FindByUserNameAsync(string userName)
    {
        var find = await Repository.FindOneAsync(x => x.UserName.Equals(userName));
        return find != null ? Mapper.Map<User, UserDto>(find) : null;
    }

    public async Task<UserDto?> FindByEmailAsync(string email)
    {
        var find = await Repository.FindOneAsync(x => x.Email.Equals(email));
        return find != null ? Mapper.Map<User, UserDto>(find) : null;
    }

    public async Task<UserDto?> FindByMobileNumberAsync(string mobileNumber)
    {
        var find = await Repository.FindOneAsync(x => x.MobileNumber.Equals(mobileNumber));
        return find != null ? Mapper.Map<User, UserDto>(find) : null;
    }
}