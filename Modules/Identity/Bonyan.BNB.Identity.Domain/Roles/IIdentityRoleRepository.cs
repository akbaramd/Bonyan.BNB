using Bonyan.BNB.DDD.Domain.Repository;

namespace Bonyan.BNB.Identity.Domain.Roles;

public interface IIdentityRoleRepository : IRepository<IdentityRole,Guid>
{
    
}