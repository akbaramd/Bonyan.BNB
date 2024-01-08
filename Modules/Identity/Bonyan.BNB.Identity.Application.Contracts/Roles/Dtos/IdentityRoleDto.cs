using Bonyan.BNB.DDD.Application.Dtos;

namespace Bonyan.BNB.Identity.Application.Contracts.Roles.Dtos;

public class IdentityRoleDto : EntityDto<Guid>
{
    public string Title { get; set; }   
    public string Name { get; set; }   
}