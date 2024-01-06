using Bonyan.BNB.DDD.Domain.Repository;

namespace Bonyan.BNB.Identity.Domain.Users;

public interface IUserRepository : IRepository<User,Guid>
{
    
}