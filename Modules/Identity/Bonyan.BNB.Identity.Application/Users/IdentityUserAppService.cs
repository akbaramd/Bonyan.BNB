using Bonyan.BNB.DDD.Application;
using Bonyan.BNB.DDD.Application.Dtos;
using Bonyan.Bnb.DependencyInjection;
using Bonyan.BNB.Identity.Application.Contracts.Users;
using Bonyan.BNB.Identity.Application.Contracts.Users.Dtos;
using Bonyan.BNB.Identity.Domain.Users;

namespace Bonyan.BNB.Identity.Application.Users;

public class IdentityUserAppService : CrudAppService<IdentityUser,IdentityUserDto,IdentityUserDto,Guid,PagedAndSortedResultRequestDto,IdentityUserCreateDto,IdentityUserUpdateDto> ,IIdentityUserAppService
{
    public IdentityUserAppService(IBnbLazyServiceProvider lazyServiceProvider) : base(lazyServiceProvider)
    {
    }
    
    public async Task<IdentityUserDto> GetByUserNameAsync(string userName)
    {
        var find = await Repository.GetOneAsync(x => x.UserName.Equals(userName));
        return Mapper.Map<IdentityUser, IdentityUserDto>(find);
    }

    public async Task<IdentityUserDto> GetByEmailAsync(string email)
    {
        var find = await Repository.GetOneAsync(x => x.Email.Equals(email));
        return Mapper.Map<IdentityUser, IdentityUserDto>(find);
    }

    public async Task<IdentityUserDto> GetByMobileNumberAsync(string mobileNumber)
    {
        var find = await Repository.GetOneAsync(x => x.MobileNumber.Equals(mobileNumber));
        return Mapper.Map<IdentityUser, IdentityUserDto>(find);
    }

    public async Task<IdentityUserDto?> FindByUserNameAsync(string userName)
    {
        var find = await Repository.FindOneAsync(x => x.UserName.Equals(userName));
        return find != null ? Mapper.Map<IdentityUser, IdentityUserDto>(find) : null;
    }

    public async Task<IdentityUserDto?> FindByEmailAsync(string email)
    {
        var find = await Repository.FindOneAsync(x => x.Email.Equals(email));
        return find != null ? Mapper.Map<IdentityUser, IdentityUserDto>(find) : null;
    }

    public async Task<IdentityUserDto?> FindByMobileNumberAsync(string mobileNumber)
    {
        var find = await Repository.FindOneAsync(x => x.MobileNumber.Equals(mobileNumber));
        return find != null ? Mapper.Map<IdentityUser, IdentityUserDto>(find) : null;
    }
}