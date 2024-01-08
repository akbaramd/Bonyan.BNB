using Bonyan.BNB.DDD.Application;
using Bonyan.BNB.DDD.Application.Dtos;
using Bonyan.Bnb.DependencyInjection;
using Bonyan.BNB.Identity.Application.Contracts.Roles;
using Bonyan.BNB.Identity.Application.Contracts.Roles.Dtos;
using Bonyan.BNB.Identity.Domain.Roles;

namespace Bonyan.BNB.Identity.Application.Users;

public class IdentityRoleAppService : CrudAppService<IdentityRole,IdentityRoleDto,IdentityRoleDto,Guid,PagedAndSortedResultRequestDto,IdentityRoleCreateDto,IdentityRoleUpdateDto> ,IIdentityRoleAppService
{
    public IdentityRoleAppService(IBnbLazyServiceProvider lazyServiceProvider) : base(lazyServiceProvider)
    {
    }
    
    public async Task<IdentityRoleDto> GetByNameAsync(string name)
    {
        var find = await Repository.GetOneAsync(x => x.Name.Equals(name));
        return Mapper.Map<IdentityRole, IdentityRoleDto>(find);
    }

   

    public async Task<IdentityRoleDto?> FindByNameAsync(string name)
    {
        var find = await Repository.FindOneAsync(x => x.Name.Equals(name));
        return find != null ? Mapper.Map<IdentityRole, IdentityRoleDto>(find) : null;
    }

}