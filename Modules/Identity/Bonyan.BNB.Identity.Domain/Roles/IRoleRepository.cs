using Bonyan.BNB.DDD.Domain.Repository;

namespace Bonyan.BNB.Identity.Domain.Roles;

public interface IRoleRepository : IRepository<Role,Guid>
{
    
}