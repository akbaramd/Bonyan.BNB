using Bonyan.BNB.DDD.Domain.Repository;
using Bonyan.BNB.Identity.Domain.Users;

namespace Bonyan.BNB.Identity.Domain.Roles;

public interface IRoleRepository : IRepository<Role,Guid>
{
    
}