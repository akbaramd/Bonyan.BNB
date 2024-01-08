using Bonyan.BNB.DDD.Domain.Repository;

namespace Bonyan.BNB.Identity.Domain.Users;

public interface IIdentityUserRepository : IRepository<IdentityUser,Guid>
{
    
}