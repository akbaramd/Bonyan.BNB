using Bonyan.BNB.DDD.Application.Dtos;
using Bonyan.BNB.DDD.Application.Services;
using Bonyan.Bnb.DependencyInjection;
using Bonyan.BNB.Identity.Application.Contracts.Roles.Dtos;

namespace Bonyan.BNB.Identity.Application.Contracts.Roles;

public interface IIdentityRoleAppService: ICrudAppService<IdentityRoleDto,IdentityRoleDto,Guid,PagedAndSortedResultRequestDto,IdentityRoleCreateDto,IdentityRoleUpdateDto>,ITransientDependency
{
    public Task<IdentityRoleDto> GetByNameAsync(string name);
    
    public Task<IdentityRoleDto?> FindByNameAsync(string name);
}