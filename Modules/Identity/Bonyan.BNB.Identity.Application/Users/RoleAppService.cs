using Bonyan.BNB.DDD.Application;
using Bonyan.BNB.DDD.Application.Dtos;
using Bonyan.Bnb.DependencyInjection;
using Bonyan.BNB.Identity.Application.Contracts.Roles;
using Bonyan.BNB.Identity.Application.Contracts.Roles.Dtos;
using Bonyan.BNB.Identity.Domain.Roles;

namespace Bonyan.BNB.Identity.Application.Users;

public class RoleAppService : CrudAppService<Role,RoleDto,RoleDto,Guid,PagedAndSortedResultRequestDto,RoleCreateDto,RoleUpdateDto> ,IRoleAppService
{
    public RoleAppService(IBnbLazyServiceProvider lazyServiceProvider) : base(lazyServiceProvider)
    {
    }
    
    public async Task<RoleDto> GetByNameAsync(string name)
    {
        var find = await Repository.GetOneAsync(x => x.Name.Equals(name));
        return Mapper.Map<Role, RoleDto>(find);
    }

   

    public async Task<RoleDto?> FindByNameAsync(string name)
    {
        var find = await Repository.FindOneAsync(x => x.Name.Equals(name));
        return find != null ? Mapper.Map<Role, RoleDto>(find) : null;
    }

}