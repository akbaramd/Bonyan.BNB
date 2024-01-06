using Bonyan.BNB.DDD.Application.Dtos;
using Bonyan.BNB.DDD.Application.Services;
using Bonyan.Bnb.DependencyInjection;
using Bonyan.BNB.Identity.Application.Contracts.Roles.Dtos;
using Bonyan.BNB.Identity.Application.Contracts.Users.Dtos;

namespace Bonyan.BNB.Identity.Application.Contracts.Roles;

public interface IRoleAppService: ICrudAppService<RoleDto,RoleDto,Guid,PagedAndSortedResultRequestDto,RoleCreateDto,RoleUpdateDto>,ITransientDependency
{
    public Task<RoleDto> GetByNameAsync(string name);
    
    public Task<RoleDto?> FindByNameAsync(string name);
}